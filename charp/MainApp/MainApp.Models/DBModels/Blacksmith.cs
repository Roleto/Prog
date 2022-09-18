using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models.DBModels
{
    public class Blacksmith
    {
        public Blacksmith()
        {

        }

        public Blacksmith(string line)
        {
            string[] help = line.Split(';');
            Id = int.Parse(help[0]);
            MaterialId = int.Parse(help[1]);
            Name = help[2];
            Damaged = bool.Parse(help[3]);
            BasePrice = int.Parse(help[4]);
            Quality = int.Parse(help[5]);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MaterialId { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        public bool Damaged { get; set; }
        public int BasePrice { get; set; }

        [Range(1, 10)]
        public int Quality { get; set; }

        public double Price { get => GetPrice(); }

        private double GetPrice()
        {

            if(Quality < 5 )
            {
                double p = (6 - Quality) * 5;
                p = (100 - p)/100;
                return BasePrice * p;
            }else if(Quality > 5)
            {
                double p = (Quality - 5) * 5;
                p = (p+100)/100;
                return BasePrice*p;
            }
            else
                return BasePrice;
        }

        public override string ToString()
        {
            return $"{Id} \t {MaterialId} \t {Name} \t {Damaged} \t {BasePrice} \t {Quality}";
        }
    }
}
