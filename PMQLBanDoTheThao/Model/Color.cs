using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMQLBanDoTheThao.Model
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }

}
