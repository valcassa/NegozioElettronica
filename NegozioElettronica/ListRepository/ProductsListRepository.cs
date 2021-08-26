using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.ListRepository
{
    class ProductsListRepository : IProductsDBManager
    {
        static List<Product> products = new List<Product>();

        public static LaptopListRepository laptoprepository = new LaptopListRepository();
        public static MobileListRepository mobilerepository = new MobileListRepository();
         public static TvListRepository tvrepository = new TvListRepository();


    }
}
