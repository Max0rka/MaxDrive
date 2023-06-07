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
    /// Логика взаимодействия для RentalPage.xaml
    /// </summary>
    public partial class RentalPage : Page
    {
        public RentalPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarsharingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridRentals.ItemsSource = CarsharingEntities.GetContext().RentalCars.ToList();

            var cars = CarsharingEntities.GetContext().Cars.ToList();
            cars.Insert(0, new Car { CarName = "Все категории" });
            ComboCars.ItemsSource = cars;

            var statuses = CarsharingEntities.GetContext().Statuses.ToList();
            statuses.Insert(0, new Status { StatusName = "Все статусы" });
            ComboStatuses.ItemsSource = statuses;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

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

        private void ComboCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDate();
        }
        private void UpdateDate()
        {
            List<RentalCar> rentalCars = CarsharingEntities.GetContext().RentalCars.ToList();
            // фильтрация
            if (ComboCars.SelectedIndex > 0 && ComboCars.SelectedItem is Car car)
                rentalCars = rentalCars.Where(p => p.CarId == car.CarId).ToList();
            if (ComboStatuses.SelectedIndex > 0 && ComboStatuses .SelectedItem is Status status)
                rentalCars = rentalCars.Where(p => p.StatusId == status.StatusId).ToList();
            // поиск клиента
            rentalCars = rentalCars.Where(p => p.Client.LastName.ToLower().Contains(TbFIOClient.Text.ToLower()) || p.Client.FirstName.ToLower().Contains(TbFIOClient.Text.ToLower()) ||
            p.Client.MiddleName.ToLower().Contains(TbFIOClient.Text.ToLower())).ToList();

            DataGridRentals.ItemsSource = rentalCars;
        }

        private void TbFIOClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDate();
        }

        private void ComboStatuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateDate();
        }
    }
}
