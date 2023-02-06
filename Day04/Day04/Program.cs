using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;

namespace Day04
{
    internal class Program
    {
        static void MyFirstRecursiveMethod(int N)
        {
            MyFirstRecursiveMethod(N + 1);
        }
        static void Main(string[] args)
        {

            ulong fac = Factorial(5);
            Console.WriteLine($"5! = {fac}");
            Console.ReadKey();

            //MyFirstRecursiveMethod(0);
            //Recursion, Sorting, Searching

            /*
                ╔═════════╗ 
                ║Recursion║
                ╚═════════╝ 
             
                Recursion happens when a method calls itself. This creates a recursive loop.
                
                All recursive methods need an exit condition, something that prevents the loop from continuing.
              
            */
            int N = 0;
            //RecursiveLoop(N);
            Console.ResetColor();


            /*
                CHALLENGE 1:

                    convert this for loop to a recursive method called Bats. Call Bats here in Main.
             
                    for(int i = 0;i < 100;i++)
                    {
                        Console.Write((char)78);
                        Console.Write((char)65);
                        Console.Write(' ');
                    }
            */
            Bats(0);
            Console.Write((char)66);
            Console.Write((char)65);
            Console.Write((char)84);
            Console.Write((char)77);
            Console.Write((char)65);
            Console.Write((char)78);
            Console.WriteLine("!!!!");





            /*
                ╔═══════╗ 
                ║Sorting║
                ╚═══════╝ 
             
                Sorting is used to order the items in a list/array is a specific way
             
                CHALLENGE 2:

                    Convert this BubbleSort pseudo-code into a C# method             
                     
                    procedure bubbleSort(A : list of sortable items)
                      n := length(A)
                      repeat
                          swapped := false
                          for i := 1 to n - 1 inclusive do
                              if A[i - 1] > A[i] then
                                  swap(A, i - 1, i)
                                  swapped = true
                              end if
                          end for
                          n := n - 1
                      while swapped
                    end procedure
                    
            */

            string s1 = "Batman", s2 = "Batmen";
            //string.CompareTo
            //returns these values:
            //  -1  means LESS THAN
            //   0  means EQUAL TO
            //   1  means GREATER THAN
            int compareResult = s1.CompareTo(s2);
            if (compareResult == 0) Console.WriteLine($"{s1} EQUALS {s2}");
            else if(compareResult == -1) Console.WriteLine($"{s1} LESS THAN {s2}");
            else if (compareResult == 1) Console.WriteLine($"{s1} GREATER THAN {s2}");

        }

        static void bubbleSort(List<int> A)
        {
            int n = A.Count;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i <= n-1; i++)
                {
                    if (A[i-1] > A[i])
                    {
                        //swap(A[i - 1], A[i]);
                        int temp = A[i];
                        A[i] = A[i - 1];
                        A[i - 1] = temp;
                        //(A[i-1], A[i]) = (A[i], A[i-1]);
                        swapped = true;
                    }
                }
                //n = n - 1;
                --n;
            } while (swapped);
        }

        static void Bats(int i)
        {
            if (i < 100)
            {
                Console.Write((char)78);
                Console.Write((char)65);
                Console.Write(' ');
                Bats(i+1);
            }
        }


        static void RecursiveLoop(int N)
        {
            //return;//jumps to the last curly brace in the method
            //an Exit Condition. This will stop the loop when N >= Console.WindowWidth
            if (N < Console.WindowWidth)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(' ');
                Thread.Sleep(20);

                RecursiveLoop(N + 1);//calls itself which makes the method recursive

                Thread.Sleep(20);
                Console.CursorLeft = N;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(' ');
            }
        }//last line of code. method is done. returns.
        static ulong Factorial(uint N)
        {
            ulong result = 1;
            if (N > 1)
            {
                result = N * Factorial(N - 1);
            }
            return result;
        }
        static ulong Factorial2(uint N)
        {
            if (N <= 1) return 1;
            ulong result = N * Factorial2(N - 1);
            return result;
        }
    }

}
