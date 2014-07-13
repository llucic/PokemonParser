using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Parser
{
    class MegaPokemonInfo
    {
        public string Name;
        public List<string> Abilities;
        public List<string> BaseStats;

        public MegaPokemonInfo()
        {
            Name = "";
            Abilities = new List<string>();
            BaseStats = new List<string>();
        }
    }
}
