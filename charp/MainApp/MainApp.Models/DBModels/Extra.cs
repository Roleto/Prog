using System;
using System.Collections.Generic;

namespace MainApp.Models.DBModels
{
    public partial class Extra
    {
        public Extra(int? modelId, int extraId, string? name, string? price)
        {
            ModelId = modelId;
            ExtraId = extraId;
            Name = name;
            Price = price;
        }

        public int? ModelId { get; set; }
        public int ExtraId { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }

        public virtual Model? Model { get; set; }

        public override string ToString()
        {
            return $"{ModelId} \t\t {ExtraId} \t\t {Name} \t {Price} ";
        }
    }
}
