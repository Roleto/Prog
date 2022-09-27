using System;
using System.Collections.Generic;

namespace MainApp.Models
{
    public partial class Recepie
    {
        public int RecepieId { get; set; }
        public string RecepieName { get; set; } = null!;
        public int MaterialId { get; set; }
        public int? MaterialQuantity { get; set; }

        public virtual Warehouse Material { get; set; } = null!;
    }
}
