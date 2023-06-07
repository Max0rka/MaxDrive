using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CarsharingApp.Entities
{
    public partial class Car
    {
        public BitmapImage CarPhoto
        {
            get
            {
                BitmapImage image = new BitmapImage();
                if (CarImage != null)
                {

                    image.BeginInit();
                    image.StreamSource = new MemoryStream(CarImage);
                    image.EndInit();
                    return image;
                }
                return null;

            }
        }
        public decimal ActualPrice => (decimal)(RentalPrice - RentalPrice * Discount / 100);
        public string RentalVisible => Manager.Client != null ? "Visible" : "Collapsed";
       
    }
}
