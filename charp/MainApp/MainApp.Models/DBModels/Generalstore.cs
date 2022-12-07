using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MainApp.Models.DBModels
{
    public class Generalstore
    {
        public Generalstore()
        {
            WareHouse = new HashSet<Warehouse>();
            Recepie = new HashSet<Recepie>();
        }

        public Generalstore(string line):this()
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
        public Generalstore(Generalstore generalstore):this()
        {
            this.Id = generalstore.Id;
            this.MaterialId = generalstore.MaterialId;
            this.Name = generalstore.Name;
            this.Price = generalstore.Price;
            this.Quality = generalstore.Quality;
            this.ExpiringDate = generalstore.ExpiringDate;
            
        }

        public Generalstore(int id, int materialId, string name, double price, int quality)
        {
            Id = id;
            MaterialId = materialId;
            Name = name;
            Price = price;
            Quality = quality;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MaterialId { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        public double Price { get; set; }

        [Range(1, 10)]
        public int Quality { get; set; }

        [AllowNull]
        public int? ExpiringDate{ get; set; }

        [JsonIgnore]
        public virtual ICollection<Warehouse> WareHouse { get; set; }
        [JsonIgnore]
        public virtual ICollection<Recepie> Recepie { get; set; }

        public override string ToString()
        {
            if (ExpiringDate == null)
                return $"{Id} \t {MaterialId} \t\t {Name} \t\t {Price} \t {Quality} \t -----";
            else
                return $"{Id} \t {MaterialId} \t\t {Name} \t\t {Price} \t {Quality} \t {ExpiringDate}";
        }
    }
}
