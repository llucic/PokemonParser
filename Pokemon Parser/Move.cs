using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Parser
{
    class Move
    {
        public string Name;
        public string Type;
        public string Category;
        public int Power;
        public int Accuracy;
        public string Description;

        public Move(string Name, string Type, string Category, int Power, int Accuracy, string Description)
        {
            this.Name = Name;
            this.Type = Type;
            this.Category = Category;
            this.Power = Power;
            this.Accuracy = Accuracy;
            this.Description = Description;
        }
    }
}
