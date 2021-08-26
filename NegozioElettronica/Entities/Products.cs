using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica
{ 
    public class Products {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }

        public Products(string brand, string model, int qta, int id)
        {
            Brand = brand;
            Model = model;
            Quantity = qta;
            Id = id;
        }

        public Products()
        {
        }

        public virtual string Print()
        {
            return $"{Brand}, {Model}";
        }
    }
}
