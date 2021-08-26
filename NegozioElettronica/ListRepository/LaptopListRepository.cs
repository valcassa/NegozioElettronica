using NegozioElettronica.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.ListRepository
{

     class LaptopListRepository : ILaptopDBManger
    {
        public static List<Laptop> laptopts = new List<Laptop>
        {
            new Laptop("HP", "I2300", 100, 030, "Windows 10 Home", false),
            new Laptop("Lenovo", "Thinkpad 200", 30, 040, "Windows 10 Pro", false),
            new Laptop("Microsoft", "Touchscreen", 10, 050, "Windows 10 Pro", true)
        };
    }
}
