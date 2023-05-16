using MintaZH3.Enum;
using PackMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH3.Entities
{
    public class Child
    {
        public string Name { get; set; }
        public Behaviour YearlyBehaviour { get; set; }
        public List<Gift> Gifts { get; set; }

        public bool CheckBehaviour(int value)
        {
            return value >= 1 && value <= 5;
        }
    }
}
