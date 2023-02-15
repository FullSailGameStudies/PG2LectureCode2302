using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public class Player : GameObject
    {
        public char Symbol { get; set; }

        //the derived constructor MUST call a base constructor
        public Player(char symbol, int x, int y) : base(x,y)
        {
            Symbol = symbol;
        }
    }
}
