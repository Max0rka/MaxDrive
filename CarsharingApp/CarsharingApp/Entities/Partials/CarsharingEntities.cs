using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsharingApp.Entities
{
    public partial class CarsharingEntities
    {
        private static CarsharingEntities _context;
        public static CarsharingEntities GetContext()
        {
            if (_context == null )
                _context = new CarsharingEntities();
            return _context;
        }
    }
}
