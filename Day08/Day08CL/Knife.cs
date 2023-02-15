using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public class Knife : Weapon
    {
        public int Length { get; set; }
        public Knife(int range, int damage) : base(range, damage)
        {
        }
    }
}
