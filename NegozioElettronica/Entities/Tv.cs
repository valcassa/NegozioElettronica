using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{
 

    public class Tv : Products
    {
        public int Inches { get; set; }

        public Tv(string brand, string model, int qta, int id, int inch)
            : base(brand, model, qta, id)
        {
            Inches = inch;

        }

        public Tv()
        {
        }
    }
}
