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
using CarsharingApp.Windows;

namespace CarsharingApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddRentalWindow.xaml
    /// </summary>
    public partial class AddRentalWindow : Window
    {
        private Car _currentCar = new Car();
        RentalCar rentalCar = new RentalCar();
        //private RentalCar _currentRental = new RentalCar();
        private decimal rentalPricePeriod = 0;
        private decimal rentalPriceService = 0;
        private decimal rentalPriceGeneral = 0;
        private DateTime dateTimeStart = DateTime.Today;
        private DateTime dateTimeEnd = DateTime.Today;
        TimeSpan timeInterval = TimeSpan.Zero;
        List<AdditionalService> _additionalServices = CarsharingEntities.GetContext().AdditionalServices.ToList();
        public AddRentalWindow(Car car, DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            InitializeComponent();
            if (car != null)
                _currentCar = car;
            DataContext = _currentCar;
            ComboAddServices.ItemsSource = _additionalServices;   
            DatePickerStart.SelectedDate = TimePickerStart.SelectedTime = this.dateTimeStart = dateTimeStart;
            DatePickerEnd.SelectedDate = TimePickerEnd.SelectedTime = this.dateTimeEnd = dateTimeEnd;
            //DatePickerStart.SelectedDate = TimePickerStart.SelectedTime = DateTime.Now;
            //DatePickerEnd.SelectedDate = TimePickerEnd.SelectedTime = DateTime.Now.AddDays(1);
            TbDay.Text = $"{car.ActualPrice:f2} p.";
        }

        private void BtnRental_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = CheckField();
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                rentalCar = new RentalCar
                {
                    CarId = _currentCar.CarId,
                    ClientId = Manager.Client.ClientId,
                    RentalStart = dateTimeStart,
                    RentalEnd = dateTimeEnd,
                    RentalPrice = rentalPriceGeneral,
                    StatusId = CarsharingEntities.GetContext().Statuses.FirstOrDefault(p => p.StatusCode == 3).StatusId
                };
                CarsharingEntities.GetContext().RentalCars.Add(rentalCar);
                _currentCar.StatusId = 2; 
                CarsharingEntities.GetContext().SaveChanges();
                SaveAdditionalServices();
                MessageBox.Show("Ожидайте, ваша заявка обрабатывается");
                Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            
        }
        private StringBuilder CheckField()
        {
            StringBuilder error = new StringBuilder();
            if (DatePickerStart.SelectedDate == null)
                error.AppendLine("Укажите дату начала аренды");
            if (TimePickerStart.SelectedTime == null)
                error.AppendLine("Укажите время начала аренды");
            if (DatePickerEnd.SelectedDate == null)
                error.AppendLine("Укажите дату сдачи автомобиля");
            if (TimePickerEnd.SelectedTime == null)
                error.AppendLine("Укажте время сдачаи автомобиля");
            return error;
        }
        private void SaveAdditionalServices()
        {
            try
            {
                List<RentalAddService> rentalAddServices = new List<RentalAddService>();
                foreach (var i in _additionalServices)
                    if (i.AddServiceSelected)
                        rentalAddServices.Add(new RentalAddService
                        {
                            RentalCarId = rentalCar.RentalCarId,
                            AddServiceId = i.AddServiceId
                        });
                CarsharingEntities.GetContext().RentalAddServices.AddRange(rentalAddServices);
                CarsharingEntities.GetContext().SaveChanges();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        private void ComboAddServices_ItemSelectionChanged(object sender, Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e)
        {
            //AdditionalService additionalService = e.Item as AdditionalService;
            //if (e.IsSelected)
            //    rentalPriceService += additionalService.AddServicePrice;
            //else
            //    rentalPriceService += additionalService.AddServicePrice;
            //if (timeInterval.Days > 0 && timeInterval.Minutes == 0)
            //    TbAddService.Text = $"{rentalPriceService * timeInterval.Days:f2} p.";
            //else
            //    TbAddService.Text = $"{rentalPriceService * (timeInterval.Days + 1):f2} p.";
            UpdateInfo();
        }

        private void TimePickerStart_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            UpdateInfo();
        }

        private void DatePickerStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateInfo();
        }

        private void DatePickerEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateInfo();
        }

        private void TimePickerEnd_SelectedTimeChanged(object sender, RoutedPropertyChangedEventArgs<DateTime?> e)
        {
            UpdateInfo();
        }
        private void UpdateInfo()
        {
           
            //if (DatePickerStart.SelectedDate != null && TimePickerStart.SelectedTime != null)
            //{
            //    DateTime dateTime = DatePickerStart.SelectedDate.Value;
            //    DateTime time = TimePickerStart.SelectedTime.Value;
            //    dateTimeStart = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, time.Hour, time.Minute, time.Second);
            //}
            //if (DatePickerEnd.SelectedDate != null && TimePickerEnd.SelectedTime != null)
            //{
            //    DateTime dateTime = DatePickerEnd.SelectedDate.Value;
            //    DateTime time = TimePickerEnd.SelectedTime.Value;
            //    dateTimeEnd = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, time.Hour, time.Minute, time.Second);
            //}
            rentalPriceService = 0;
            foreach (var i in _additionalServices)
                if (i.AddServiceSelected)
                    rentalPriceService += i.AddServicePrice;
            timeInterval = dateTimeEnd.Subtract(dateTimeStart);
            if (timeInterval.Days > 0 && timeInterval.Minutes == 0)
            {
                rentalPricePeriod = _currentCar.ActualPrice * timeInterval.Days;
                rentalPriceService = rentalPriceService * timeInterval.Days;
            }

            else
            {
                rentalPriceService = rentalPriceService * (timeInterval.Days + 1);
                rentalPricePeriod = _currentCar.ActualPrice * (timeInterval.Days + 1);
            }
            rentalPriceGeneral = rentalPricePeriod + rentalPriceService;
            TbPeriod.Text = $"{rentalPricePeriod:f2} p.";
            TbAddService.Text = $"{rentalPriceService:f2} p.";
            TbGeneral.Text = $"{rentalPriceGeneral:f2} p.";
        }
    }
}
