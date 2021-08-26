using NegozioElettronica.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.ListRepository
{
    class TvListRepository : ITvDBManager
    {
        public static List<Tv> tvs = new List<Tv>
        {
            new Tv("Samsung", "I001", 20, 020, 40),
            new Tv("Sharp", "T002", 40, 010, 30),
            new Tv("Philips", "C003", 50, 015, 20)
        };
    }
 
    
}
