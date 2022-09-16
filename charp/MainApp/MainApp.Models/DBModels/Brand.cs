using Castle.Components.DictionaryAdapter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace MainApp.Models.DBModels
{
    public class Brand
    {
        public Brand()
        {

        }
        public Brand(string line)
        {
            string[] help = line.Split(';');
            if (help.Length == 1)
            {
                BrandName = line;
            }
            else
            {
                BrandId = int.Parse(help[0]);
                BrandName = help[1];
            }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        [StringLength(240)]
        public string BrandName { get; set; }

        public override string ToString()
        {
            return $"{BrandId} \t {BrandName}";
        }
    }
}
