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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarsharingApp.Entities;
using CarsharingApp.Pages;
using Microsoft.Win32;

namespace CarsharingApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditCarPage.xaml
    /// </summary>
    public partial class AddOrEditCarPage : Page
    {
        private Car _currentCar = new Car();
        private string textInfo = "изменена";
        public AddOrEditCarPage(Car car)
        {
            InitializeComponent();
            if (car != null)
            {
                _currentCar = car;
            }
            DataContext = _currentCar;
            ComboCarClasses.ItemsSource = CarsharingEntities.GetContext().CarClasses.ToList();
            ComboDriveUnits.ItemsSource = CarsharingEntities.GetContext().DriveUnits.ToList();
            ComboGearboxTypes.ItemsSource = CarsharingEntities.GetContext().GearboxTypes.ToList();
            ComboStatuses.ItemsSource = CarsharingEntities.GetContext().Statuses.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = CheckField();
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                if (_currentCar.CarId == 0)
                {
                    textInfo = "добавлена";
                    CarsharingEntities.GetContext().Cars.Add(_currentCar);
                }

                CarsharingEntities.GetContext().SaveChanges();
                MessageBox.Show("Запись " + textInfo);
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        
        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog() { Title = "Загрузить", Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif" };
                if (op.ShowDialog() == true)
                {
                    // проверка на размер файла
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > 1024 * 1024 * 2)
                        throw new Exception("Размер файла не больше 2 мб");
                    ImageCar.Source = new BitmapImage(new Uri(op.FileName));
                    Stream stream = File.OpenRead(op.FileName);
                    byte[] binaryImage = new byte[stream.Length];
                    stream.Read(binaryImage, 0, (int)stream.Length);
                    _currentCar.CarImage = binaryImage;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        private StringBuilder CheckField()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentCar.CarName))
                error.AppendLine("Введите название авто");
            if (ComboGearboxTypes.SelectedItem == null)
                error.AppendLine("Выберите тип трансмисии");
            if (ComboDriveUnits.SelectedItem == null)
                error.AppendLine("Выберите тип привода");
            if (ComboCarClasses.SelectedItem == null)
                error.AppendLine("Выберите класс авто");
            if (ComboStatuses.SelectedItem == null)
                error.AppendLine("Укажите статус авто");
            if (_currentCar.RentalPrice < 0)
                error.AppendLine("Цена аренды не может быть меньше 0");
            if (_currentCar.AvgConsumption < 0)
                error.AppendLine("Средний расход не может быть меньше 0");
            if (_currentCar.Discount < 0 || _currentCar.Discount > 100)
                error.AppendLine("Размер скидки в диапазоне от 0 до 100");
            
            return error;
        }
    }
}
