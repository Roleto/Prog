using System;
using System.Collections.Generic;

namespace MainApp.Models.DBModels
{
    public partial class Model
    {
        public Model()
        {
            Extras = new HashSet<Extra>();
        }

        public int? BrandId { get; set; }
        public int ModelId { get; set; }
        public string? ModelName { get; set; }
        public string? Type { get; set; }
        public int? BasePrice { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ICollection<Extra> Extras { get; set; }
    }
}
