using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarsharingApp.Entities
{
    public  class Manager
    {
        public static Frame MainFrame {  get; set; } 
        public static Client Client { get; set; }
        public static bool AdminLogin { get; set; } = false;
    }
}
