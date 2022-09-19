﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models.DBModels
{
    public class WareHouse
    {
        public WareHouse()
        {

        }

        public WareHouse(string line)
        {
            string[] help = line.Split(';');
            Id = int.Parse(help[0]);
            Name = help[1];
            MaterialType = help[2];
            Price = int.Parse(help[3]);
            Quantity = int.Parse(help[4]);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(240)]
        [NotNull]
        public string Name { get; set; }

        //etc food, minerals,ore
        [StringLength(240)]
        public string MaterialType { get; set; }
        public int Price { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public int SumPrice { get => Quantity * Price; }

        public override string ToString()
        {
            int matlenght = MaterialType.Length;
            int namelenght = Name.Length;
            if(matlenght < 8 && namelenght < 6)
                return $"{Id} \t {Name} \t {MaterialType} \t\t {Price} \t {Quantity}";
            else if(namelenght < 6)
                return $"{Id} \t {Name} \t {MaterialType} \t {Price} \t {Quantity}";
            else
                return $"{Id} \t {Name}  {MaterialType}  \t\t {Price} \t {Quantity}";

        }
    }
}
