using System;
using System.Collections.Generic;

namespace MainApp.Models
{
    public partial class Generalstore
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string Name { get; set; } = null!;
        public int? Price { get; set; }
        public int Quality { get; set; }
        public int? ExpiringDate { get; set; }

        public virtual Warehouse Material { get; set; } = null!;
    }
}
