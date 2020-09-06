using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsPool.Models
{
    public interface IProductRepository
    {
        IEnumerable<Pool> Pools { get; }
        void Add(Pool pool);
    }
}
