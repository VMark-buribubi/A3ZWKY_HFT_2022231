﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}