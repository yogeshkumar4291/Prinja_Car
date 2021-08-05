using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prinja_Car.Models
{
    public class Buy
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

    }
}
