using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3ZWKY_HFT_2022231.Logic
{
    public abstract class IdGeneratorUtil
    {
        private static int lastID = 100;
        public static int GenerateId()
        {
            return ++lastID;
        }
    }
}
