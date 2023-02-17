namespace Day09
{
    enum Superpower
    {
        LazerVision, Flight, Speed, Money, Knowledge, Strength
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Gotham!");

            Calculator t1000 = new();
            int n1 = 5, n2 = 2;
            int sum = t1000.Sum(n1,n2);
            Console.WriteLine($"{n1} + {n2} = {sum}");

            t1000.SelfDestruct();
            Superpower myPower = Superpower.LazerVision;
            myPower.PrintMe();

        }
    }

    /*  
        ╔═════════════╗ 
        ║ OVERLOADING ║ - polymorphism by changing parameters
        ╚═════════════╝ 

        You can overload a method in 3 ways:
        1) different types on the parameters
        2) different number of parameters
        3) different order of parameters


        CHALLENGE 1:
            Add a overload of the Sum method to sum 2 doubles
    */

    static class Extensions
    {
        public static void SelfDestruct(this Calculator bob)
        {
            Console.WriteLine("BOOM! John Connor is DEAD?");
        }

        public static void PrintMe(this Superpower powers)
        {
            switch (powers)
            {
                case Superpower.LazerVision:
                    Console.BackgroundColor = ConsoleColor.Red;                    
                    break;
                case Superpower.Flight:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case Superpower.Speed:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case Superpower.Money:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case Superpower.Knowledge:
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case Superpower.Strength:
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                default:
                    break;
            }
            Console.WriteLine(powers);
        }
    }

    class Calculator
    {
        public int Sum(int n1, int n2)
        {
            return n1 + n2;
        }

        public double Sum(double n1, double n2)//this
        {
            return n1 + n2;
        }
    }
}