using DreamsPool.Controllers;
using DreamsPool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsPool.Models
{
    public class EfAdminRepository : IAdminRepository
    {
        DbAppContext context;

        public EfAdminRepository(DbAppContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Admin> Admins => context.Admins;

       
    }
}
