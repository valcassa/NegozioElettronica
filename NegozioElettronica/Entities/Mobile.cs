using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{ 
    class Mobile : Products
    {
        public int Storage { get; set; }
 
        public Mobile(string brand, string model, int qta, int id, int gb)
            : base(brand, model, qta, id)
        {
            Storage = gb;

        }

        public Mobile()
        {
        }
    }
}