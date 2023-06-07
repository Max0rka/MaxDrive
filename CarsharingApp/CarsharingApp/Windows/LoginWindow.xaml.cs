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
using CarsharingApp.Entities;

namespace CarsharingApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Client> clients = CarsharingEntities.GetContext().Clients.ToList();
                Client client = clients.FirstOrDefault(p => p.Login == TbLogin.Text && p.Password == TbPassword.Password);
                if (client != null)
                {
                    Manager.Client = client;
                    DialogResult = true;
                }
                else if (TbLogin.Text == "admin" && TbPassword.Password == "777")
                {
                    Manager.AdminLogin = true;
                    DialogResult = true;
                }
                else
                    MessageBox.Show("Не верный логин или пароль");
                
            } catch(Exception ex) { ex.Message.ToString(); }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            RegClientWindow regClientWindow = new RegClientWindow(null);
            regClientWindow.ShowDialog();
        }
    }
}
