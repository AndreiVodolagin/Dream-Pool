using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsPool.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> Customers { get; }
        void Add(Customer customer);

    }
}
