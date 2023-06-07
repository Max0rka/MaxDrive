using CarsharingApp.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddOrEditDriveUnitWindow.xaml
    /// </summary>
    public partial class AddOrEditDriveUnitWindow : Window
    {
        private DriveUnit _currentDriveUnit = new DriveUnit();
        private string textInfo = "изменена";
        public AddOrEditDriveUnitWindow(DriveUnit driveUnit)
        {
            InitializeComponent();
            if (driveUnit != null)
                _currentDriveUnit = driveUnit;
            DataContext = _currentDriveUnit;
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
                if (_currentDriveUnit.DriveUnitId == 0)
                {
                    textInfo = "добавлена";
                    CarsharingEntities.GetContext().DriveUnits.Add(_currentDriveUnit);
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
            if (string.IsNullOrWhiteSpace(_currentDriveUnit.DriveUnitName))
                error.AppendLine("Введите тип привода");
            return error;
        }
    }
}
