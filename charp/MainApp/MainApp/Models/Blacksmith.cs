using System;
using System.Collections.Generic;

namespace MainApp.Models
{
    public partial class Blacksmith
    {
        public int Id { get; set; }
        public int? MaterialId { get; set; }
        public string? Name { get; set; }
        public string? Damaged { get; set; }
        public int? BasePrice { get; set; }
        public int? Quality { get; set; }

        public virtual Warehouse? Material { get; set; }
    }
}
