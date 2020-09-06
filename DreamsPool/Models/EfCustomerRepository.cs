using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsPool.Models
{
    public class EfCustomerRepository : ICustomerRepository
    {
        DbAppContext context;

        public EfCustomerRepository(DbAppContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Customer> Customers => context.Customers;

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        /*public async void Add(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
        }*/
    }
}
