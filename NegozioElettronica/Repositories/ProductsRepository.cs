using NegozioElettronica.Entities;
using NegozioElettronica.ListRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Repositories
{
    class ProductsRepository : IProductsDBManager
    {

        public static MobileRepository mobileRepository = new MobileRepository();
        public static LaptopRepository laptopRepository = new LaptopRepository();
        public static TvRepository tvRepository = new TvRepository();

        public static List<Products> Fetch()

        {
            List<Products> products = new List<Products>();

            products.AddRange(mobileRepository.Fetch());
            products.AddRange(laptopRepository.Fetch());
            products.AddRange(tvRepository.Fetch());

            return products;
        }

        internal void Delete(Products product)
        {
            throw new NotImplementedException();
        }

        internal void Update(Products product)
        {
            throw new NotImplementedException();
        }

        internal static void Insert(Products product)
        {
            throw new NotImplementedException();
        }
    }
}
