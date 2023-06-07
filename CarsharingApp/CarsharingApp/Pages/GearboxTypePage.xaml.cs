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
    /// Логика взаимодействия для GearboxTypePage.xaml
    /// </summary>
    public partial class GearboxTypePage : Page
    {
        public GearboxTypePage()
        {
            InitializeComponent();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            CarsharingEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DataGridGearboxTypes.ItemsSource = CarsharingEntities.GetContext().GearboxTypes.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridGearboxTypes.SelectedItem is GearboxType gearboxType)
            {
                AddOrEditGearboxWindow addOrEditGearbox = new AddOrEditGearboxWindow(gearboxType);
                addOrEditGearbox.ShowDialog();
                Page_IsVisibleChanged(null, default);
            }
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить данную запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (DataGridGearboxTypes.SelectedItem is GearboxType gearboxType)
            {
                try
                {
                    if (gearboxType.Cars.Count > 0)
                        throw new Exception("Существуют записи в производных таблицах, удаление запрещено!");
                    CarsharingEntities.GetContext().GearboxTypes.Remove(gearboxType);
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
            AddOrEditGearboxWindow addOrEditGearbox = new AddOrEditGearboxWindow(null);
            addOrEditGearbox.ShowDialog();
            Page_IsVisibleChanged(null, default);
        }


    }
}
