//// Action.cs
//using System.Collections.Generic;
//using System.Windows;
//using System.Windows.Controls;
//using CourseWork_2;

//namespace CourseWork_2
//{
//    public static class Action
//    {
//        // Метод для загрузки марок автобусов в ComboBox
//        public static void LoadBusBrands(ComboBox comboBox)
//        {
//            // Создание экземпляра класса Data
//            var data = new Data();

//            // Чтение и десериализация JSON
//            var busBrands = data.Read();

//            // Проверка на пустой список
//            if (busBrands.Count == 0)
//            {
//                MessageBox.Show("Список марок автобусов пуст!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
//            }
//            else
//            {
//                // Заполнение ComboBox марками автобусов
//                comboBox.ItemsSource = busBrands;

//                // Для выбора первого элемента (если есть)
//                comboBox.SelectedIndex = 0;
//            }
//        }
//    }
//}
