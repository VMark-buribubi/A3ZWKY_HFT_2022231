using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Models
{
    abstract class HouseInfo
    {
        public string Address { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"{Address} - {Count}";
        }
    }
}
