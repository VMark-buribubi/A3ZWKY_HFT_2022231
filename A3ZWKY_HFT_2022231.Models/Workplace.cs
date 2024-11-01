﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Models
{
    [Table("Workplace")]
    public class Workplace
    {
        [Key]
        public int WorkplaceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string TelephoneNumber { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
        public Workplace()
        {
            this.Persons = new HashSet<Person>();
        }

        public override string ToString()
        {
            return $"{WorkplaceId} - {Name} - {Type} - {TelephoneNumber} - {Address}";
        }
        public override bool Equals(object obj)
        {
            return obj is Workplace workplace &&
                   WorkplaceId == workplace.WorkplaceId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(WorkplaceId);
        }
    }
}
