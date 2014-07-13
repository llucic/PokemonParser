using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Parser
{
    class PokemonInfo
    {
        public string Name;
        public List<string> Abilities;
        public string HiddenAbility;
        public List<string> LevelUpMoves;
        public List<string> TmMoves;
        public List<string> EggMoves;
        public List<string> TutorMoves;
        public List<string> SpecialMoves;
        public List<string> PreEvoMoves;
        public List<string> TransferMoves;
        public List<string> BaseStats;

        public PokemonInfo()
        {
            Name = "";
            Abilities = new List<String>();
            LevelUpMoves = new List<string>();
            TmMoves = new List<string>();
            EggMoves = new List<string>();
            TutorMoves = new List<string>();
            SpecialMoves = new List<string>();
            PreEvoMoves = new List<string>();
            TransferMoves = new List<string>();
            BaseStats = new List<string>();
            HiddenAbility = "";
        }
    }
}
