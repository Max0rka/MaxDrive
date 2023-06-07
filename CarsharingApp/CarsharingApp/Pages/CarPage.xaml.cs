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
using CarsharingApp.Entities;
using CarsharingApp.Pages;
using CarsharingApp.Windows;
using Xceed.Wpf.Toolkit;

namespace CarsharingApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для CarPage.xaml
    /// </summary>
    public partial class CarPage : Page
    {
        private DateTime dateTimeStart = DateTime.Today;
        private DateTime dateTimeEnd = DateTime.Today;
        public CarPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarsharingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            ListViewCars.ItemsSource = CarsharingEntities.GetContext().Cars.ToList();
            DatePickerStart.SelectedDate = TimePickerStart.SelectedTime = dateTimeStart = DateTime.Now;
            DatePickerEnd.SelectedDate = TimePickerEnd.SelectedTime =  dateTimeEnd = DateTime.Now.AddDays(1);

            var carClasses = CarsharingEntities.GetContext().CarClasses.ToList();
            carClasses.Insert(0, new CarClass { CarClassName = "Все категории" });
            ComboCarClasses.ItemsSource = carClasses;

            var gearboxTypes = CarsharingEntities.GetContext().GearboxTypes.ToList();
            gearboxTypes.Insert(0, new GearboxType { GearboxTypeName = "Все категории" });
            ComboGearboxTypes.ItemsSource = gearboxTypes;

            var unitTypes = CarsharingEntities.GetContext().DriveUnits.ToList();
            unitTypes.Insert(0, new DriveUnit { DriveUnitName = "Все категории" });
            ComboUnitTypes.ItemsSource = unitTypes;

            UpdateDate();
        }

        private void BtnRental_Click(object sender, RoutedEventArgs e)
        {
            AddRentalWindow addRentalWindow = new AddRentalWindow(((Button)sender).DataContext as Car, dateTimeStart, dateTimeEnd);
            addRentalWindow.ShowDialog();
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
        private void TbCarName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDate();
        }
        private void UpdateDate()
        {
            List<Car> cars = CarsharingEntities.GetContext().Cars.ToList();
            List<RentalCar> rentalCars = CarsharingEntities.GetContext().RentalCars.ToList();

            // загрузка свободных машин
            cars = cars.Where(p => p.RentalCars.FirstOrDefault(k => !((k.RentalStart <= dateTimeStart && k.RentalEnd <= dateTimeStart) && (k.RentalStart <= dateTimeEnd && k.RentalEnd <= dateTimeEnd))) == null).ToList();
            // фильтрация
            if (ComboCarClasses.SelectedIndex > 0 && ComboCarClasses.SelectedItem is CarClass carClass)
                cars = cars.Where(p => p.CarClassId == carClass.CarClassId).ToList();
            if (ComboGearboxTypes.SelectedIndex > 0 && ComboGearboxTypes.SelectedItem is GearboxType gearboxType)
                cars = cars.Where(p => p.GearboxTypeId == gearboxType.GearboxTypeId).ToList();
            if (ComboUnitTypes.SelectedIndex > 0 && ComboUnitTypes.SelectedItem is DriveUnit driveUinit)
                cars = cars.Where(p => p.DriveUnitId == driveUinit.DriveUnitId).ToList();
            switch (ComboSort.SelectedIndex)
            {
                case 0:
                    cars = cars.OrderBy(p => p.ActualPrice).ToList();
                    break;
                case 1:
                    cars = cars.OrderByDescending(p => p.ActualPrice).ToList();
                    break;
                case 2:
                    cars = cars.OrderBy(p => p.CarName).ToList();
                    break;
                case 3:
                    cars = cars.OrderByDescending(p => p.CarName).ToList();
                    break;
            }
            
            // поиск автомобиля
            cars = cars.Where(p => p.CarName.ToLower().Contains(TbCarName.Text.ToLower())).ToList();

            ListViewCars.ItemsSource = cars;
        }

        private void DatePickerStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePickerStart.SelectedDate != null && TimePickerStart.SelectedTime != null)
            {
                DateTime dateTime = DatePickerStart.SelectedDate.Value;
                DateTime time = TimePickerStart.SelectedTime.Value;
                dateTimeStart = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, time.Hour, time.Minute, time.Second);
            }
            UpdateDate();
        }

        private void TimePickerStart_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (DatePickerStart.SelectedDate != null && TimePickerStart.SelectedTime != null)
            {
                DateTime dateTime = DatePickerStart.SelectedDate.Value;
                DateTime time = TimePickerStart.SelectedTime.Value;
                dateTimeStart = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, time.Hour, time.Minute, time.Second);
            }
            UpdateDate();
        }

        private void DatePickerEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePickerEnd.SelectedDate != null && TimePickerEnd.SelectedTime != null)
            {
                DateTime dateTime = DatePickerEnd.SelectedDate.Value;
                DateTime time = TimePickerEnd.SelectedTime.Value;
                dateTimeEnd = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, time.Hour, time.Minute, time.Second);
            }
            UpdateDate();
        }

        private void TimePickerEnd_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            if (DatePickerEnd.SelectedDate != null && TimePickerEnd.SelectedTime != null)
            {
                DateTime dateTime = DatePickerEnd.SelectedDate.Value;
                DateTime time = TimePickerEnd.SelectedTime.Value;
                dateTimeEnd = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, time.Hour, time.Minute, time.Second);
            }
            UpdateDate();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDate();
        }
    }
}
