using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual House House { get; set; }
        public virtual Workplace Workplace { get; set; }
        public int HouseId { get; set; }
        public int? WorkplaceId { get; set; }
        public override string ToString()
        {
            return $"{PersonId} - {Name} - {Age} - {Gender} - {BirthDate}";
        }
    }
}
