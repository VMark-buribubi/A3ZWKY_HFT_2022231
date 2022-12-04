using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace A3ZWKY_HFT_2022231.Models
{
    [Table("House")]
    public class House
    {
        [Key]
        public int HouseId { get; set; }
        public string Color { get; set; }
        public int FloorArea { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Person> Persons { get;set; }

        public House()
        {
            this.Persons = new HashSet<Person>();
        }
        public override string ToString()
        {
            return $"{HouseId} - {Color} - {FloorArea} - {Address}";
        }

        public override bool Equals(object obj)
        {
            return obj is House house &&
                   HouseId == house.HouseId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(HouseId);
        }
    }
}
