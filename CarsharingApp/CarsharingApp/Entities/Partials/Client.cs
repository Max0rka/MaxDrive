using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CarsharingApp.Entities
{
    public partial class Client
    {
        public BitmapImage ClientPhoto
        {
            get
            {
                BitmapImage image = new BitmapImage();
                if (ClientImage != null)
                {

                    image.BeginInit();
                    image.StreamSource = new MemoryStream(ClientImage);
                    image.EndInit();
                    return image;
                }
                else
                {
                    if (ClientId != 0 && Gender)
                        return new BitmapImage(new Uri("/Assets/man.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                    else if (ClientId != 0 && !Gender)
                        return new BitmapImage(new Uri("/Assets/woman.png", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                    else return null;
                }

            }
        }
        public string GenderName => Gender ? "мужской" : "женский";
        public string ClientFullName => $"{LastName} {FirstName} {MiddleName}";
    }
}
