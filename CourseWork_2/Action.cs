//// Action.cs
//using System.Collections.Generic;
//using System.Windows;
//using System.Windows.Controls;
//using CourseWork_2;

//namespace CourseWork_2
//{
//    public static class Action
//    {
//        // ����� ��� �������� ����� ��������� � ComboBox
//        public static void LoadBusBrands(ComboBox comboBox)
//        {
//            // �������� ���������� ������ Data
//            var data = new Data();

//            // ������ � �������������� JSON
//            var busBrands = data.Read();

//            // �������� �� ������ ������
//            if (busBrands.Count == 0)
//            {
//                MessageBox.Show("������ ����� ��������� ����!", "������", MessageBoxButton.OK, MessageBoxImage.Error);
//            }
//            else
//            {
//                // ���������� ComboBox ������� ���������
//                comboBox.ItemsSource = busBrands;

//                // ��� ������ ������� �������� (���� ����)
//                comboBox.SelectedIndex = 0;
//            }
//        }
//    }
//}
