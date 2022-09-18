using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models.DBModels
{
    public class Recepies
    {
        public Recepies()
        {

        }

        public Recepies(string line)
        {
            string[] help = line.Split(';');
            RecepieId = int.Parse(help[0]);
            RecepieName = help[1];
            MaterialId = int.Parse(help[2]);
            MaterialQuantity = int.Parse(help[3]);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecepieId { get; set; }

        [StringLength(240)]
        public string RecepieName { get; set; }

        [NotNull]
        [Required]
        public int MaterialId { get; set; }
        
        [NotNull]
        [Required]
        public int MaterialQuantity { get; set; }

        public override string ToString()
        {
            return $"{RecepieId} \t {RecepieName} \t {MaterialId} \t {MaterialQuantity}";
        }
    }
}
