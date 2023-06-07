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
    /// Логика взаимодействия для DriveUnitPage.xaml
    /// </summary>
    public partial class DriveUnitPage : Page
    {
        public DriveUnitPage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarsharingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridDriveUnits.ItemsSource = CarsharingEntities.GetContext().DriveUnits.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridDriveUnits.SelectedItem is DriveUnit driveUnit)
            {
                AddOrEditDriveUnitWindow addOrEditDriveUnitWindow = new AddOrEditDriveUnitWindow(driveUnit);
                addOrEditDriveUnitWindow.ShowDialog();
                Page_IsVisibleChanged(null, default);
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (DataGridDriveUnits.SelectedItem is DriveUnit driveUnit)
            {
                try
                {
                    if (driveUnit.Cars.Count > 0)
                        throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    CarsharingEntities.GetContext().DriveUnits.Remove(driveUnit);
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
            AddOrEditDriveUnitWindow addOrEditDriveUnitWindow = new AddOrEditDriveUnitWindow(null);
            addOrEditDriveUnitWindow.ShowDialog();
            Page_IsVisibleChanged(null, default);
        }
    }
}
