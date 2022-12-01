using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Models
{
    abstract class IdGeneratorUtil
    {
        static int lastID = 100;
        static int GenerateId()
        {
            return ++lastID;
        }
    }
}
