using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsharingApp.Entities
{
    public partial class RentalCar
    {
        public string RentalServicesName
        {
            get
            {
                string listService = "";
                foreach (var i in RentalAddServices)
                    listService += $"{i.AdditionalService.AddServiceName}, ";
                if (listService.Length > 2)
                    listService = listService.Remove(listService.Length - 2);
                return listService;
            }
        }
        public string BtnEditVisible => CarsharingEntities.GetContext().Statuses.FirstOrDefault(p => p.StatusCode == 4) != null ? "Visible" : "Collapsed";
    }
    
}
