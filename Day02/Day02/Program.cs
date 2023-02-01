using System;
using System.Collections.Generic;
using System.Linq;

namespace Day02
{
    /*                    METHODS          
                                                               
                ╔══════╗ ╔═══╗ ╔══════════╗ ╔════════════════╗ 
                ║public║ ║int║ ║SomeMethod║ ║(int someParam) ║ 
                ╚══════╝ ╚═══╝ ╚══════════╝ ╚════════════════╝ 
                    │      │         │               │         
              ┌─────┘      │         └──┐            └───┐     
         ┌────▼────┐   ┌───▼───┐   ┌────▼───┐       ┌────▼────┐
         │ Access  │   │ Return│   │ Method │       │Parameter│
         │ modifier│   │ type  │   │  Name  │       │  list   │
         └─────────┘   └───────┘   └────────┘       └─────────┘


    
    ╔═══════════╗ 
    ║Return type║ Return type defines the type of the data being returned.
    ╚═══════════╝
    │
    │
    └── If NO data is returned, then use "void" for the return type.
    │    public void PrintSomething()
    │    {
    │        Console.WriteLine("Something");
    │    }
    │
    │
    └── If a method returns data, then the return type must match the type of the data being returned.
        public float GetMyGrade()
        {
            return 99.9F; //returning a float so set return type to float
        }

    ╔══════════╗ 
    ║Parameters║ Parameters define the data passed to the method.
    ╚══════════╝
    │
    │
    └── If NO data is passed to the method, leave the parenthesis empty. EX: ( )
    │    public void PrintSomething()
    │   {  }
    │
    │
    └── If passing data to the method, then define the variable the method will use to store the data.
        Parameters are just variables therefore parameters need 2 things: <type> <name>
        Example:
        public void PrintMyGrade(float myGrade)
        {
            Console.WriteLine($"My grade is {myGrade}");
        }

        

     */
    internal class Program
    {
        static Random randy = new Random();
        static void Main(string[] args)
        {

            /*   
                ╔══════════════════════════════╗ 
                ║Parameters: Pass by Reference.║
                ╚══════════════════════════════╝ 
                Sends the variable itself to the method. The method parameter gives the variable a NEW name (i.e. an alias)
                  
                NOTE: if the method assigns a new value to the parameter, the variable used when calling the method will change too.
                    This is because the parameter is actually just a new name for the other variable.
            */
            string spider = "Spiderman";
            bool isEven = PostFix(ref spider);
            Console.WriteLine($"{spider}. Is postfix even? {isEven}");
            string bats = "The Bat";
            do
            {
                isEven = PostFix(ref bats);
                Console.WriteLine($"{bats}. Is postfix even? {isEven}"); 
            } while (isEven);
            Console.ReadKey();

            /*
                CHALLENGE 1:

                    Write a method to curve the grade variable.
                    1) pass it in by reference
                    2) calculate a 5% curve
                    3) curve the parameter in the method
                    4) return the letter grade
             
            */
            double grade = randy.NextDouble() * 100;
            Console.WriteLine($"Current Grade: {grade:N2}");
            char letterGrade = CurveGrade(ref grade, out double curved);
            Console.WriteLine($"Curved grade: {letterGrade} {grade:N2} (curved by {curved:N2})");
            Console.ReadKey();



            /*  
                ╔═══════════════════════════╗ 
                ║Parameters: Out Parameters.║
                ╚═══════════════════════════╝  
                  A special pass by reference parameter. 
                  DIFFERENCES:
                    the out parameter does NOT have to be initialized before sending to the method
                    the method MUST assign a value to the parameter before returning

            */
            ConsoleColor randoColor; //don't have to initialize it
            GetRandomColor(out randoColor);
            Console.BackgroundColor = randoColor;
            Console.WriteLine("Hello Gotham!");
            Console.ResetColor();


            /*
                CHALLENGE 2:

                    Write a method to calculate the stats on a list of grades
                    1) create a list of grades in main and add a few grades to it
                    2) create a method to calculate the min, max, and avg. 
                        use out parameters to pass this data back from the method.
                    3) print out the min, max, and avg
             
            */






            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Removing from a List  ]

                There are 2 main ways to remove from a list:
                1) bool Remove(item).  will remove the first one in the list that matches item. returns true if a match is found else removes false.
                2) RemoveAt(index). will remove the item from the list at the index

            */
            List<string> dc = new() { "Batman", "Wonder Woman", "Aquaman", "Superman", "Aquaman" };
            bool found = dc.Remove("Aquaman");

            dc.RemoveAt(dc.Count - 1);//removes the last item

            /*
                CHALLENGE 3:

                    Using the list of grades you created in CHALLENGE 2, remove the min and max grades from the list.
                    Print the grades.
            */




        }

        private static char CurveGrade(ref double studentGrade, out double curveAmount)
        {
            curveAmount = studentGrade * 0.05;
            studentGrade += curveAmount;
            studentGrade = Math.Min(studentGrade, 100);//cap the grade at 100
            //C# ternary operator
            return (studentGrade < 59.5) ? 'F' :
                   (studentGrade < 69.5) ? 'D' :
                   (studentGrade < 79.5) ? 'C' :
                   (studentGrade < 89.5) ? 'B' :
                   'A';
        }

        private static void GetRandomColor(out ConsoleColor outColor)
        {
            //the method MUST initialize the outColor parameter
            while ((outColor = (ConsoleColor)randy.Next(16)) == ConsoleColor.DarkYellow) ;

        }

        static bool PostFix(ref string hero) //hero is now an alias to the variable used when calling PostFix. In this case, hero is an alias to the spider variable.
        {
            int postFix = randy.Next(100);
            hero += $"-{postFix}"; //updating hero now also updates spider
            return postFix % 2 == 0; //isEven
        }
        //tuples
    }
}
