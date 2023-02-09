using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hello = "Hello Gotham!";
            Console.WriteLine(hello[0]);

            Console.WriteLine(hello.Substring(0,1));
        }
    }
}