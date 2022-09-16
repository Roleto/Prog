using System;
using System.Collections.Generic;

namespace MainApp.Models.DBModels
{
    public partial class Extra
    {
        public int? ModelId { get; set; }
        public int ExtraId { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }

        public virtual Model? Model { get; set; }

        public override string ToString()
        {
            return $"{ModelId} \t {ExtraId} \t {Name} \t {Price}";
        }
    }
}
