using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsPool.Models
{
    public class EfProductRepository : IProductRepository
    {
        DbAppContext context;

        public EfProductRepository(DbAppContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Pool> Pools => context.Pools;

        public void Add(Pool pool)
        {
            if (pool != null)
                context.Pools.Add(pool);
        }
    }
}
