using System;
using System.Collections.Generic;

namespace MainApp.Models.DBModels
{
    public partial class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }

        public int BrandId { get; set; }
        public string? BrandName { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
