using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    public class Pistol : Weapon
    {
        // = new Weapon(range, damage)
        public Pistol(int rounds, int magCapacity, int range, int damage) : base(range, damage)
        {
            Rounds = rounds;
            MagCapacity = magCapacity;
            Console.WriteLine(Range);
        }

        public int Rounds { get; set; }
        public int MagCapacity { get; }

        public override void ShowMe()
        {
            base.ShowMe();
            Console.WriteLine($"Rounds: {Rounds} MagCapacity: {MagCapacity}");
        }
    }
}
