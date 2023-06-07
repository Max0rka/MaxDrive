using CarsharingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarsharingApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditGearboxWindow.xaml
    /// </summary>
    public partial class AddOrEditGearboxWindow : Window
    {
        private GearboxType _currentGearboxType = new GearboxType();
        private string textInfo = "изменена";
        public AddOrEditGearboxWindow(GearboxType gearboxType)
        {
            InitializeComponent();
            if (gearboxType != null)
                _currentGearboxType = gearboxType;
            DataContext = _currentGearboxType;
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = CheckField();
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (_currentGearboxType.GearboxTypeId == 0)
                {
                    textInfo = "добавлена";
                    CarsharingEntities.GetContext().GearboxTypes.Add(_currentGearboxType);
                }

                CarsharingEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись " + textInfo);

                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private StringBuilder CheckField()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentGearboxType.GearboxTypeName))
                error.AppendLine("Введите тип трансмиссии");
            return error;
        }
    }
}
