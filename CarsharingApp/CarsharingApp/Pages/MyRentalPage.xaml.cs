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
    /// Логика взаимодействия для MyRentalPage.xaml
    /// </summary>
    public partial class MyRentalPage : Page
    {
        public MyRentalPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarsharingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridRentals.ItemsSource = CarsharingEntities.GetContext().RentalCars.Where(p => p.ClientId == Manager.Client.ClientId).ToList();

            var cars = CarsharingEntities.GetContext().Cars.ToList();
            cars.Insert(0, new Car { CarName = "Все категории" });
            ComboCars.ItemsSource = cars;

            var statuses = CarsharingEntities.GetContext().Statuses.ToList();
            statuses.Insert(0, new Status { StatusName = "Все статусы" });
            ComboStatuses.ItemsSource = statuses;
        }

        private void ComboCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDate();
        }

        private void ComboStatuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDate();
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите отменить данную запись?", "Отмена", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (DataGridRentals.SelectedItem is RentalCar rentalCar)
            {
                try
                {
                    CarsharingEntities.GetContext().RentalAddServices.RemoveRange(rentalCar.RentalAddServices);
                    CarsharingEntities.GetContext().RentalCars.Remove(rentalCar);
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
            List<RentalCar> rentalCars = CarsharingEntities.GetContext().RentalCars.Where(p => p.ClientId == Manager.Client.ClientId).ToList();
            // фильтрация
            if (ComboCars.SelectedIndex > 0 && ComboCars.SelectedItem is Car car)
                rentalCars = rentalCars.Where(p => p.CarId == car.CarId).ToList();
            if (ComboStatuses.SelectedIndex > 0 && ComboStatuses.SelectedItem is Status status)
                rentalCars = rentalCars.Where(p => p.StatusId == status.StatusId).ToList();          

            DataGridRentals.ItemsSource = rentalCars;
        }
    }
}
