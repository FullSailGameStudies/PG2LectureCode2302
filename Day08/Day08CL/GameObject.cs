using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day08CL
{
    //Pascal Casing
    //  TheNameOfTheClass
    public class GameObject
    {
        public static int NumberOfGameObjects = 0;

        public static void DebugInfo() //NO 'this' parameter
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"# game objects: {NumberOfGameObjects}");
        }
        //camelCasing
        public virtual void ShowMe(int posX)//hidden parameter: GameObject this. this is the instance that it was called on
        {
            //local variables:
            //  camelCamelCasing
            int x = 5 + posX;
            _x = x + 1;
            Console.WriteLine($"X: {X} Y: {Y} # game objects: {NumberOfGameObjects}");
        }

        //C# naming convention for fields:
        //  _camelCamelCasing
        protected int _x = 10;

        public int GetX() { return _x; }
        public void SetX(int value) { _x = value; }

        public int X
        {
            get { return _x; }
            set
            { //param called value
                if (value >= 0 && value < Console.WindowWidth)
                    _x = value;
            }
        }

        public int Y { get; private set; } //an auto-property

        //constructors: methods that initialize your instances of your class
        //compiler will give us a default constructor IFF we do not write our own
        //ctor (constructor)
        //public GameObject() //default constructor (no parameters)
        //{
        //    X = 0;
        //    Y = 0;
        //}
        public GameObject(int x, int y)
        {
            //x = X;//BACKWARDS
            X = x;
            Y = y;
        }
    }
}
