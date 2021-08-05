using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prinja_Car.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Customer_Name { get; set; }
        public DateTime DOB { get; set; }
        public string Customer_Address { get; set; }
        public string Customer_Contact { get; set; }
    }
}
