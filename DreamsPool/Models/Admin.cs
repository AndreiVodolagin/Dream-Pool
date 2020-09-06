using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsPool.Models
{ 
    public class Admin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string SlacKey { get; set; }
    }
}
