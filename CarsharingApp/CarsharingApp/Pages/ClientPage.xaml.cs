using CarsharingApp.Entities;
using CarsharingApp.Windows;
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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        private void TbFIOClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDate();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarsharingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridClients.ItemsSource = CarsharingEntities.GetContext().Clients.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            RegClientWindow regClientWindow = new RegClientWindow(null);
            regClientWindow.ShowDialog();
            UpdateDate();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridClients.SelectedItem is Client client)
            {
                RegClientWindow regClientWindow = new RegClientWindow(client);
                regClientWindow.ShowDialog();
                UpdateDate();
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && DataGridClients.SelectedItem is Client client)
            {
                try
                {
                    if (client.RentalCars.Count > 0)
                        throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    CarsharingEntities.GetContext().Clients.Remove(client);
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
            CarsharingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            List<Client> clients = CarsharingEntities.GetContext().Clients.ToList();
            
            // поиск клиента
            clients = clients.Where(p => p.LastName.ToLower().Contains(TbFIOClient.Text.ToLower()) || p.FirstName.ToLower().Contains(TbFIOClient.Text.ToLower()) ||
            p.MiddleName.ToLower().Contains(TbFIOClient.Text.ToLower())).ToList();

            DataGridClients.ItemsSource = clients;
        }

        
    }
}
