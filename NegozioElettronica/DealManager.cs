using NegozioElettronica.Entities;
using NegozioElettronica.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.DBManager
{
    class DealManager
    {

        public static ProductsRepository productRepository = new ProductsRepository();
        public static MobileRepository  mobileRepository = new MobileRepository();
        public static LaptopRepository laptopRepository = new LaptopRepository();
        public static TvRepository  tvRepository = new TvRepository();

        internal static void ShowProducts()
        {
            List<Products> products = ProductsRepository.Fetch();
            foreach (var product in products)
            {
                Console.WriteLine(product.Print());
            }
        }

        internal static void ShowMobile()
        {
            List<Mobile> mobiles = mobileRepository.Fetch();
            foreach (var mobile in mobiles)
            {
                Console.WriteLine(mobile.Print());
            }
        }

        internal static void ShowLaptop()
        {
            List<Laptop> laptops = laptopRepository.Fetch();
            foreach (var laptop in laptops)
            {
                Console.WriteLine(laptop.Print());
            }
        }

        internal static void ShowTv()
        {
            List<Tv> tvs = tvRepository.Fetch();
            foreach (var tv in tvs)
            {
                Console.WriteLine(tv.Print());
            }
        }

        internal static void InsertProducts()
        {
            int prodottoScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Scegli il prodotto da inserire?");
                Console.WriteLine("1 - Cellulare");
                Console.WriteLine("2 - Computer");
                Console.WriteLine("3 - Tv");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto >= 4);

            switch (prodottoScelto)
            {
                case 1:
                    Mobile mobile = ChiediDatiCellulare();
                    mobileRepository.Insert(mobile);
                    break;
                case 2:
                    Laptop laptop = ChiediDatiLaptop();
                    laptopRepository.Insert(laptop); 
                    break;
                case 3:
                    Tv tv = ChiediDatiTv();
                    tvRepository.Insert(tv);
                    break;
            }

        }
 

        private static Mobile ChiediDatiCellulare()
        {
            Products product = ChiediDatiProdotti();
            Mobile mobile = new Mobile();
            mobile.Brand = product.Brand;
            mobile.Model = product.Model;

            int Storage;
            bool isInt;
            do
            {
                Console.WriteLine("Inserisci i GB");
                isInt = int.TryParse(Console.ReadLine(), out Storage);
            } while (!isInt);
            mobile.Storage = Storage;

            return mobile;
        }

        private static Products ChiediDatiProdotti()
        {
            Products product = new Products();
            Console.WriteLine("Inserisci la marca");
            product.Brand = Console.ReadLine();

            Console.WriteLine("Inserisci il modello");
            product.Model = Console.ReadLine();

            return product;
        
        }

        private static Laptop ChiediDatiLaptop()
        {
            Products product = ChiediDatiProdotti();
            Laptop laptop = new Laptop();
            laptop.Brand = product.Brand;
            laptop.Model = product.Model;

            string OpSystem;
            Console.WriteLine("Inserisci il Sistema Operativo");
            OpSystem = Console.ReadLine();
 
            return laptop;
        }

        private static Tv ChiediDatiTv()
        {
            Products product = ChiediDatiProdotti();
            Tv tv = new Tv();
            tv.Brand = product.Brand;
            tv.Model = product.Model;
             
            int Inches;
            bool isInt;
            do
            {
                Console.WriteLine("Inserisci la dimensione in pollici");
                isInt = int.TryParse(Console.ReadLine(), out Inches);
            } while (!isInt);
            tv.Inches = Inches;

            return tv;
        }

        internal static void UpdateProducts()
        {
            List<Products> products = ProductsRepository.Fetch();
            int i = 1;
            foreach (var p in products)
            {
                Console.WriteLine($"Premi {i} per modificare il prodotto {p.Print()}");
                i++;
            }
            int prodottoScelto;
            bool isInt;

            do
            {
                Console.WriteLine("Quale prodotto?");


                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto > products.Count);

            Console.WriteLine("Hai scelto di modificare");
            Products product = products.ElementAt(prodottoScelto - 1);
            if (product.Id == null)
            {
                productRepository.Delete(product);
            }

            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Vuoi modificare il Modello?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                product.Model = InsertModel();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la marca?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                product.Brand = InsertBrand();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la quantità?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                product.Quantity = InsertQta();
            }

            productRepository.Update(product);
        }

        //private static string InsertProduct()
        //{
        //    Products product = new Products();

        //    product.Model = InsertModel();
        //    product.Brand = InsertBrand();
        //    product.Quantity = InsertQta(); 

        //    ProductsRepository.Insert(product);

        //}

        private static int InsertQta()
        {
            Products product = new Products();

            int qta;
            bool isInt;

            do
            {
                Console.WriteLine("Inserisci la quantità");

                isInt = int.TryParse(Console.ReadLine(), out qta);

            } while (!isInt);

            product.Quantity = qta;

            return qta;

        }

        private static string InsertBrand()
        {
            string brand = String.Empty;
            do
            {
                Console.WriteLine("Inserisci la marca");
                brand = Console.ReadLine();

            } while (String.IsNullOrEmpty(brand));
            return brand;
        }

        private static string InsertModel()
        {
            string model = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il modello");
                model = Console.ReadLine();

            } while (String.IsNullOrEmpty(model));
            return model;
        }

        

        internal static void DeleteProducts()
        {
            List<Products> products = ProductsRepository.Fetch();

            int i = 1;
            foreach (var user in products)
            {
                Console.WriteLine($"Scrivi {i} per eliminare il prodotto {user.Print()}");
                i++;
            }

            bool isInt;
            int prodottoScelto;
            do
            {
                Console.WriteLine("Scegli il prodotto da rimuovere");

                isInt = int.TryParse(Console.ReadLine(), out prodottoScelto);

            } while (!isInt || prodottoScelto <= 0 || prodottoScelto > products.Count);

            productRepository.Delete(products.ElementAt(prodottoScelto - 1));
        }

        internal static void ShowbyMemory()
        {
            throw new NotImplementedException();
        }

        internal static void ShowbySO()
        {
            throw new NotImplementedException();
        }

        internal static void ShowbySize()
        {
            throw new NotImplementedException();
        }
    }
}
