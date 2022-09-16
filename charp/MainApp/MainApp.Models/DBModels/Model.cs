using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainApp.Models.DBModels
{
    public partial class Model
    {
        public Model()
        {

        }
        public Model(int brandId, string modelName, string type, int basePrice)
        {
            BrandId = brandId;
            ModelName = modelName;
            Type = type;
            BasePrice = basePrice;
        }

        public Model(string line)
        {
            string[] help = line.Split(';');
            BrandId = int.Parse(help[0]);
            ModelId = int.Parse(help[1]);
            ModelName = help[2];
            Type = help[3]; 
            BasePrice = int.Parse(help[4]);
        }

        public int BrandId { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ModelId { get; set; }

        [StringLength(240)]
        public string ModelName { get; set; }

        [StringLength(240)]
        public string Type { get; set; }
        public int BasePrice { get; set; }

        public override string ToString()
        {
            if (Type.Length < 6)
                return $"{BrandId} \t\t {ModelId} \t\t {ModelName} \t {Type} \t\t {BasePrice}";
            else
                return $"{BrandId} \t\t {ModelId} \t\t {ModelName} \t {Type} \t {BasePrice}";
        }
    }
}
