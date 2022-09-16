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

        public Brand(int brandId, string? brandName)
        {
            BrandId = brandId;
            BrandName = brandName;
        }

        public int BrandId { get; set; }
        public string? BrandName { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public override string ToString()
        {
            return $"{BrandId} \t {BrandName}";
        }
    }
}
