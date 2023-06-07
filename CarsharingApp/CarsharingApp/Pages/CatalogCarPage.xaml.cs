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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarsharingApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogCarPage.xaml
    /// </summary>
    public partial class CatalogCarPage : Page
    {
        public CatalogCarPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarsharingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridCars.ItemsSource = CarsharingEntities.GetContext().Cars.ToList();

            var carClasses = CarsharingEntities.GetContext().CarClasses.ToList();
            carClasses.Insert(0, new CarClass { CarClassName = "Все категории" });
            ComboCarClasses.ItemsSource = carClasses;

            var gearboxTypes = CarsharingEntities.GetContext().GearboxTypes.ToList();
            gearboxTypes.Insert(0, new GearboxType { GearboxTypeName = "Все категории" });
            ComboGearboxTypes.ItemsSource = gearboxTypes;

            var unitTypes = CarsharingEntities.GetContext().DriveUnits.ToList();
            unitTypes.Insert(0, new DriveUnit { DriveUnitName = "Все категории" });
            ComboUnitTypes.ItemsSource = unitTypes;
        }

        private void TbCarName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDate();
        }

        private void ComboCarClasses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDate();
        }

        private void ComboGearboxTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDate();
        }

        private void ComboUnitTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDate();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new AddOrEdittCarPage(null);
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new AddOrEdittCarPage(((Button)sender).DataContext as Car);
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && DataGridCars.SelectedItem is Car car)
            {
                try
                {
                    if (car.RentalCars.Count > 0)
                        throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    CarsharingEntities.GetContext().Cars.Remove(car);
                    CarsharingEntities.GetContext().SaveChanges();
                    MessageBox.Show("Запись удалена!");
                    Page_IsVisibleChanged(null, default);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void UpdateDate()
        {
            List<Car> cars = CarsharingEntities.GetContext().Cars.ToList();
            // фильтрация
            if (ComboCarClasses.SelectedIndex > 0 && ComboCarClasses.SelectedItem is CarClass carClass)
                cars = cars.Where(p => p.CarClassId == carClass.CarClassId).ToList();
            if (ComboGearboxTypes.SelectedIndex > 0 && ComboGearboxTypes.SelectedItem is GearboxType gearboxType)
                cars = cars.Where(p => p.GearboxTypeId == gearboxType.GearboxTypeId).ToList();
            if (ComboUnitTypes.SelectedIndex > 0 && ComboUnitTypes.SelectedItem is DriveUnit driveUinit)
                cars = cars.Where(p => p.DriveUnitId == driveUinit.DriveUnitId).ToList();

            // поиск автомобиля
            cars = cars.Where(p => p.CarName.ToLower().Contains(TbCarName.Text.ToLower())).ToList();

            DataGridCars.ItemsSource = cars;
        }

        private void BtnGearboxType_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new GearboxTypePage();
        }

        private void BtnDriveUnit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new DriveUnitPage();
        }

        private void BtnCarClass_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new CarClassPage();
        }
    }
}
