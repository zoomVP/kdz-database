using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEmilitary
{
    [Serializable]
    class Soldier
    {
        public uint Age { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public uint Efficiency { get; set; }

        public Soldier(uint age, string name, string rank, uint eff)
        {
            Age = age;
            Name = name;
            Rank = rank;
            Efficiency = eff;
        }
    }
}
