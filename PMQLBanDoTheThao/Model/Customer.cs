using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLBanDoTheThao.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } // Khớp với cột Name
        public string Phone { get; set; } // Khớp với cột Phone
        public string Address { get; set; } // Khớp với cột Address
    }
}
