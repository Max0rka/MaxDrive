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
    /// Логика взаимодействия для AddOrEditAddServiceWindow.xaml
    /// </summary>
    public partial class AddOrEditAddServiceWindow : Window
    {
        private AdditionalService _currentAddService = new AdditionalService();
        private string textInfo = "изменена";
        public AddOrEditAddServiceWindow(AdditionalService addService)
        {
            InitializeComponent();
            if (addService != null)
                _currentAddService = addService;
            DataContext = _currentAddService;
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
                if (_currentAddService.AddServiceId == 0)
                {
                    textInfo = "добавлена";
                    CarsharingEntities.GetContext().AdditionalServices.Add(_currentAddService);
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
            if (string.IsNullOrWhiteSpace(_currentAddService.AddServiceName))
                error.AppendLine("Введите название доп. услуги");
            if (_currentAddService.AddServicePrice < 0)
                error.AppendLine("Цена услуги не может быть отрицательной");
            return error;
        }
    }
}
