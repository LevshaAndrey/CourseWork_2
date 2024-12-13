using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace CourseWork_2
{
    public partial class TransportPage : Window
    {
        private BusData busData;
        private string dataFilePath;

        public TransportPage()
        {
            InitializeComponent();

            dataFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "bus_data.json");
            busData = BusData.LoadFromJson(dataFilePath);

            busesDataGrid.ItemsSource = busData.Buses;

            brandBoardComboBox.ItemsSource = LoadCombinedData(
                Path.Combine(Directory.GetCurrentDirectory(), "Resources", "bus_brands.json"),
                Path.Combine(Directory.GetCurrentDirectory(), "Resources", "board_numbers.json")
            );

            routeComboBox.ItemsSource = LoadSimpleData(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "route_numbers.json"));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Закрываем текущую страницу
            this.Close();

            // Открываем главную страницу
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }


        private List<string> LoadCombinedData(string brandsFilePath, string boardNumbersFilePath)
        {
            if (File.Exists(brandsFilePath) && File.Exists(boardNumbersFilePath))
            {
                var brands = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(brandsFilePath));
                var boardNumbers = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(boardNumbersFilePath));

                return boardNumbers.Zip(brands, (board, brand) => $"{board} - {brand}").ToList();
            }
            else
            {
                MessageBox.Show($"One of the files is missing: {brandsFilePath} or {boardNumbersFilePath}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<string>();
            }
        }

        private List<string> LoadSimpleData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<string>>(json);
            }
            else
            {
                MessageBox.Show($"File not found: {filePath}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return new List<string>();
            }
        }

        private void OnAddTransportButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedBrandBoard = brandBoardComboBox.SelectedItem as string;
            var selectedRouteNumber = routeComboBox.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedBrandBoard) || string.IsNullOrEmpty(selectedRouteNumber))
            {
                MessageBox.Show("Please select all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var parts = selectedBrandBoard.Split(" - ");
                var boardNumber = parts[0];
                var brand = parts[1];

                var newBus = new Bus
                {
                    BoardNumber = boardNumber,
                    Brand = brand,
                    RouteNumber = selectedRouteNumber
                };

                busData.Buses.Add(newBus);
                busesDataGrid.Items.Refresh();

                busData.SaveToJson(dataFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnDeleteTransportButtonClick(object sender, RoutedEventArgs e)
        {
            if (busesDataGrid.SelectedItem is Bus selectedBus)
            {
                busData.Buses.Remove(selectedBus);
                busesDataGrid.Items.Refresh();
                busData.SaveToJson(dataFilePath);
            }
            else
            {
                MessageBox.Show("Please select a transport item to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
