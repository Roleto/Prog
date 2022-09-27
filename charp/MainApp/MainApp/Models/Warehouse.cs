using System;
using System.Collections.Generic;

namespace MainApp.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Blacksmiths = new HashSet<Blacksmith>();
            Generalstores = new HashSet<Generalstore>();
            Recepies = new HashSet<Recepie>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MaterialType { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual ICollection<Blacksmith> Blacksmiths { get; set; }
        public virtual ICollection<Generalstore> Generalstores { get; set; }
        public virtual ICollection<Recepie> Recepies { get; set; }
    }
}
