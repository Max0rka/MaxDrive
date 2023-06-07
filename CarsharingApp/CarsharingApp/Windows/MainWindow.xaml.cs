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

namespace CarsharingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new CarPage();
            Manager.MainFrame = MainFrame;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            UpdateButtons();
        }
        private void UpdateButtons()
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
                BtnExit.Visibility = Visibility.Collapsed;
                BtnLogin.Visibility = Visibility.Collapsed;
                StackPanelAdmin.Visibility = Visibility.Collapsed;
                StackPanelUser.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnBack.Visibility = Visibility.Collapsed;
                BtnLogin.Visibility = Visibility.Visible;
                BtnExit.Visibility = Visibility.Collapsed;
                if (Manager.Client != null)
                {
                    StackPanelUser.Visibility = Visibility.Visible;
                    BtnLogin.Visibility = Visibility.Collapsed;
                    BtnExit.Visibility = Visibility.Visible;
                }
                    
                else if (Manager.AdminLogin)
                {
                    StackPanelAdmin.Visibility = Visibility.Visible;
                    BtnLogin.Visibility = Visibility.Collapsed;
                    BtnExit.Visibility = Visibility.Visible;
                }
                else
                {
                    StackPanelAdmin.Visibility = Visibility.Collapsed;
                    StackPanelUser.Visibility = Visibility.Collapsed;
                }
                   
            }
        }

        private void BtnCar_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new CatalogCarPage();

        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ClientPage();
        }

        private void BtnRental_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new RentalPage();
        }

        private void BtnMyProfile_Click(object sender, RoutedEventArgs e)
        {
            RegClientWindow regClientWindow = new RegClientWindow(Manager.Client);
            regClientWindow.ShowDialog();
        }

        private void BtnMyRental_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MyRentalPage();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            
            if (loginWindow.ShowDialog() == true)
            {
                UpdateButtons();
                MainFrame.NavigationService.Refresh();
            }
            
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Выйти из данной учетной записи?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Manager.AdminLogin = false;
                Manager.Client = null;
                UpdateButtons();
                MainFrame.NavigationService.Refresh();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Закрыть приложение?","Выход", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.Cancel)
                e.Cancel = true;
        }

        private void BtnAddItionalService_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AdditionalServicePage();
        }
    }
}
