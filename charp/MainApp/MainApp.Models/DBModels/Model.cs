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

        public Model(int? brandId, int modelId, string? modelName, string? type, int? basePrice)
        {
            BrandId = brandId;
            ModelId = modelId;
            ModelName = modelName;
            Type = type;
            BasePrice = basePrice;
        }

        public int? BrandId { get; set; }
        public int ModelId { get; set; }
        public string? ModelName { get; set; }
        public string? Type { get; set; }
        public int? BasePrice { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ICollection<Extra> Extras { get; set; }

        public override string ToString()
        {
            return $"{BrandId} \t\t {ModelId} \t\t {ModelName} \t {Type} \t {BasePrice}";
        }
    }
}
