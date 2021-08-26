using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{ 

    public class Laptop : Products
    {
        public string OpSystem { get; set; }
        public bool Touch { get; set; }

        public Laptop(string brand, string model, int qta, int id, string op, bool t)
            : base(brand, model, qta, id)
        { 
            OpSystem = op;
            Touch = t;

        }

        public Laptop()
        {
        }

        public override string Print()
        {
            return $"{base.Print()}";
        }
    }
}
