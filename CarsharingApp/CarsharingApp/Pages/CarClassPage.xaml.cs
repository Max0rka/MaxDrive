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
    /// Логика взаимодействия для CarClassPage.xaml
    /// </summary>
    public partial class CarClassPage : Page
    {
        public CarClassPage()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarsharingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridCarClasses.ItemsSource = CarsharingEntities.GetContext().CarClasses.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCarClasses.SelectedItem is CarClass carClass)
            {
                AddOrEditCarClassWindow addOrEditCarClassWindow = new AddOrEditCarClassWindow(carClass);
                addOrEditCarClassWindow.ShowDialog();
                Page_IsVisibleChanged(null, default);
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (DataGridCarClasses.SelectedItem is CarClass carClass)
            {
                try
                {
                    if (carClass.Cars.Count > 0)
                        throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    CarsharingEntities.GetContext().CarClasses.Remove(carClass);
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

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditCarClassWindow addOrEditCarClassWindow = new AddOrEditCarClassWindow(null);
            addOrEditCarClassWindow.ShowDialog();
            Page_IsVisibleChanged(null, default);
        }
    }
}
