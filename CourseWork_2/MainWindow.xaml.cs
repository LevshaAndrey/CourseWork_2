using System.Windows;

namespace CourseWork_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик кнопки для открытия страницы водителя
        private void OpenDriverPage(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр страницы "Водитель" и открываем её
            DriverPage driverPage = new DriverPage();
            driverPage.Show();
            this.Close();  // Закрываем текущую страницу (MainWindow)
        }

        // Обработчик кнопки для открытия страницы транспорта
        private void OpenTransportPage(object sender, RoutedEventArgs e)
        {
            // Создаем экземпляр страницы "Транспорт" и открываем её
            TransportPage transportPage = new TransportPage();
            transportPage.Show();
            this.Close();  // Закрываем текущую страницу (MainWindow)
        }

        // Обработчик кнопки выхода
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Закрываем приложение
        }
    }
}
