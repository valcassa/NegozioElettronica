using NegozioElettronica.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.ListRepository
{
     class MobileListRepository : IMobileDBManager
    {
        public static List<Mobile> mobiles = new List<Mobile>
        {
            new Mobile("Apple", "IphoneX", 20, 021, 65),
            new Mobile("Nokia", "XPeria 20", 15, 022, 128),
            new Mobile("Huawei", "Y20", 60, 023, 256)
        };
        public void Delete(Mobile mob)
        {
            mobiles.Remove(mob);
        }

        public List<Mobile> Fetch()
        {
            return mobiles;
        }

        public Mobile GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Mobile t)
        {
            throw new NotImplementedException();
        }

        public void Update(Mobile t)
        {
            throw new NotImplementedException();
        }
    }
}
