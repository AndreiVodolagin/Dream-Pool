using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamsPool.Models
{
    public class Pool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Shape Shape { get; set; }
    }

    public enum Shape
    {
        Rect,
        Round
    }
}
