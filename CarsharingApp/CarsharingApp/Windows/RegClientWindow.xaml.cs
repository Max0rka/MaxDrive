using CarsharingApp.Entities;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace CarsharingApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegClientWindow.xaml
    /// </summary>
    public partial class RegClientWindow : Window
    {
        private Client _currentClient = new Client();
        string textInfo = "изменена";
        public RegClientWindow(Client client)
        {
            InitializeComponent();
            if (client != null)
            {
                _currentClient = client;
                if (_currentClient.Gender)
                    RButtonM.IsChecked = true;
                else
                    RButtonF.IsChecked = true;
                TbOldPass.Text = "Старый пароль";
                TbLogin.IsEnabled = false;
                PassEditCheck.Visibility = Visibility.Visible;
                TbNewPass.Visibility = Visibility.Visible;
                TextBNewPass.Visibility = Visibility.Visible;
            }
            else
            {               
                _currentClient.DateOfBirth = DateTime.Today;
            }    
            DataContext = _currentClient;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder error = CheckField();
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                if (_currentClient.ClientId == 0)
                {
                    textInfo = "добалена";
                    _currentClient.Password = TbPass.Password;
                    CarsharingEntities.GetContext().Clients.Add(_currentClient);
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
                    ClientImage.Source = new BitmapImage(new Uri(op.FileName));
                    Stream stream = File.OpenRead(op.FileName);
                    byte[] binaryImage = new byte[stream.Length];
                    stream.Read(binaryImage, 0, (int)stream.Length);
                    _currentClient.ClientImage = binaryImage;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
        private StringBuilder CheckField()
        {
            StringBuilder error = new StringBuilder();            
            if (string.IsNullOrWhiteSpace(_currentClient.LastName))
                error.AppendLine("Введите фамилию");
            if (string.IsNullOrWhiteSpace(_currentClient.FirstName))
                error.AppendLine("Введите имя");
            if (RButtonM.IsChecked == null && RButtonM.IsChecked == null)
                error.AppendLine("Выберите пол");
            if (string.IsNullOrWhiteSpace(_currentClient.Phone))
                error.AppendLine("Введите номер телефона");
            if (string.IsNullOrWhiteSpace(_currentClient.DriveLicenseNum))
                error.AppendLine("Введите номер прав");
            if (string.IsNullOrWhiteSpace(_currentClient.Login))
                error.AppendLine("Введите логин");
            else
            {
                Client client = CarsharingEntities.GetContext().Clients.FirstOrDefault(p => p.Login == _currentClient.Login);
                if (_currentClient.ClientId == 0 && client != null)
                    error.AppendLine("Указанный логин уже занят");
                //else if (_currentClient.ClientId != 0 && _currentClient.ClientId != client.ClientId)
            }
            if (_currentClient.ClientId == 0)
            {
                if (string.IsNullOrWhiteSpace(TbPass.Password))
                    error.AppendLine("Введите пароль");
                if (TbPass.Password != TbPassRepeat.Password)
                    error.AppendLine("Введенные пароли не совпадают");
            }
            else if (PassEditCheck.IsChecked == true)
            {
                if (string.IsNullOrWhiteSpace(TbPass.Password))
                    error.AppendLine("Введите старый пароль");
                else if (TbPass.Password != _currentClient.Password)
                    error.AppendLine("Старый пароль введен неверно");
                if (string.IsNullOrWhiteSpace(TbNewPass.Password))
                    error.AppendLine("Введите новый пароль");
                else if (TbPassRepeat.Password != TbNewPass.Password)
                    error.AppendLine("Введенные пароли не совпадают");
                else
                    _currentClient.Password = TbNewPass.Password;
            }
            
            return error;
        }

        private void RButtonM_Checked(object sender, RoutedEventArgs e)
        {
            _currentClient.Gender = true;
        }

        private void RButtonF_Checked(object sender, RoutedEventArgs e)
        {
            _currentClient.Gender = false;
        }
    }
}
