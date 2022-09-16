using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;


namespace MainApp.Models.DBModels
{
    public partial class Extra
    {
        public Extra()
        {

        }
        public Extra(int modelId, string name, int price)
        {
            ModelId = modelId;
            Name = name;
            Price = price;
        }
        public Extra(string line)
        {
            string[] help = line.Split(';');
            ModelId = int.Parse(help[0]);
            ExtraId = int.Parse(help[1]);
            Name = help[2];
            Price = int.Parse(help[3]);

        }

        public int ModelId { get; set; }
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExtraId { get; set; }

        [StringLength(240)]
        public string Name { get; set; }
        
        public int Price { get; set; }

        public override string ToString()
        {
            if (Name.Length < 6)
                return $"{ModelId} \t\t {ExtraId} \t\t {Name} \t\t {Price} ";
            else
                return $"{ModelId} \t\t {ExtraId} \t\t {Name} \t {Price} ";
        }
    }
}
