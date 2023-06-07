using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsharingApp.Entities
{
    public partial class AdditionalService
    {
        public string AddServiceNamePice => $"{AddServiceName} - {AddServicePrice:f2} p.";
        public bool AddServiceSelected { get; set; } = false;
    }
}
