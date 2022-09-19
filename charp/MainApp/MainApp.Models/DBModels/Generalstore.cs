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
    public class Generalstore
    {
        public Generalstore()
        {
        }

        public Generalstore(string line)
        {
            string[] help = line.Split(';');
            Id = int.Parse(help[0]);
            MaterialId = int.Parse(help[1]);
            Name = help[2];
            Price = int.Parse(help[3]);
            Quality = int.Parse(help[4]);
            int tryhelp;
            if (int.TryParse(help[5], out tryhelp))
                ExpiringDate = tryhelp;
            else
                ExpiringDate = null;
                
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MaterialId { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        public int Price { get; set; }

        [Range(1, 10)]
        public int Quality { get; set; }

        [AllowNull]
        public int? ExpiringDate{ get; set; }

        public override string ToString()
        {
            if (ExpiringDate == null)
                return $"{Id} \t {MaterialId} \t\t {Name} \t\t {Price} \t {Quality} \t -----";
            else
                return $"{Id} \t {MaterialId} \t\t {Name} \t\t {Price} \t {Quality} \t {ExpiringDate}";
        }
    }
}
