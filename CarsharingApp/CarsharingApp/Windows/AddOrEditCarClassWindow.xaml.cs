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
using CarsharingApp.Entities;

namespace CarsharingApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditCarClassWindow.xaml
    /// </summary>
    public partial class AddOrEditCarClassWindow : Window
    {
        private CarClass _currentCarClass = new CarClass();
        private string textInfo = "изменена";
        public AddOrEditCarClassWindow(CarClass carClass)
        {
            InitializeComponent();
            if (carClass != null)
                _currentCarClass = carClass;
            DataContext = _currentCarClass;
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
                if (_currentCarClass.CarClassId == 0)
                {
                    textInfo = "добавлена";
                    CarsharingEntities.GetContext().CarClasses.Add(_currentCarClass);
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
            if (string.IsNullOrWhiteSpace(_currentCarClass.CarClassName))
                error.AppendLine("Введите название класса авто");
            return error;
        }
    }
}
