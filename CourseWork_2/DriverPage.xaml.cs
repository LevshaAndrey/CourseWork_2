using System;
using System.Collections.Generic;
using System.Windows;

namespace CourseWork_2
{
    public partial class DriverPage : Window
    {
        private List<Driver> drivers;

        public DriverPage()
        {
            InitializeComponent();
            drivers = new List<Driver>();
            driversListBox.ItemsSource = drivers;  // Set the listbox's data context
        }

        private void OnSaveDriverButtonClick(object sender, RoutedEventArgs e)
        {
            string surname = surnameTextBox.Text;
            string name = nameTextBox.Text;
            string patronymic = patronymicTextBox.Text;
            DateTime? workDate = workDatePicker.SelectedDate;

            if (string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(patronymic) || workDate == null)
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newDriver = new Driver
            {
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                WorkDate = workDate.Value
            };

            drivers.Add(newDriver);  // Add the driver to the list
            driversListBox.Items.Refresh();  // Refresh the ListBox

            MessageBox.Show($"Driver saved:\nSurname: {surname}\nName: {name}\nPatronymic: {patronymic}\nWork date: {workDate.Value.ToShortDateString()}",
                "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear the fields after adding the driver
            surnameTextBox.Clear();
            nameTextBox.Clear();
            patronymicTextBox.Clear();
            workDatePicker.SelectedDate = null;
        }
    }
}
