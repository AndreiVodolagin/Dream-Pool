using DreamsPool.Models;
using System.Collections.Generic;

namespace DreamsPool.Controllers
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> Admins { get; }
    }
}