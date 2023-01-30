using System;
using System.Collections.Generic;

namespace Day01
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
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Hello Gotham. What is your name?");
            string name = Console.ReadLine();
            //$ - interpolated string
            Console.WriteLine($"Hello {name}.");
            /*
              Calling a method
                use the methods name.
                1) if the method needs data (i.e. has parameters), you must pass data to the method that matches the parameter types
                2) if the method returns data, it is usually best to store that data in a variable on the line where you call the method.
             
            */

            /*
                ╔══════════════════════════╗ 
                ║Parameters: Pass by Value.║
                ╚══════════════════════════╝ 
             
                Copies the value to a new variable in the method.
                
                For example, the AddOne method has a parameter called localNumber. localNumber is a variable that is local ONLY to the method.
                The value of the variable in main, number, is COPIED to the variable in AddOne, localNumber.
              
            */
            int number = 5;
            int plusOne = AddOne(number);

            /*
                CHALLENGE 1:

                    call the Sum method on the t1000 calculator. Print the sum that is returned.
             
            */
            Calculator t1000 = new Calculator();//t1000 is an INSTANCE of the Calculator class

            int number1 = 5, number2 = 2;

            int result = t1000.Sum(number1, number2);//arguments -- values you pass in for parameters

            Console.WriteLine($"{number1} + {number2} = {result}");



            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 
                
                [  Creating a List  ]
                
                List<T>  - the T is a placeholder for a type. It is a "Generic Type Parameter" to the class.
                
                When you want to create a List variable, replace T with whatever type of data you want to store in the List.
            */
            List<string> names = new List<string>(10); //this list stores strings and only strings.
            PrintInfo(names);//Count: 0  Capacity: 0
            names.Add("The Dark Knight");
            PrintInfo(names);//Count: 1  Capacity: 4
            names.Add("Bruce");
            names.Add("Batman");
            names.Add("World's Greatest Detective");
            PrintInfo(names);//Count: 4  Capacity: 4
            names.Add("The Bat");
            PrintInfo(names);//Count: 5  Capacity: 8, 12?, random?
            names.Add("Joker");
            names.Add("Riddler");
            names.Add("Bane");
            names.Add("Mr Freeze");
            PrintInfo(names);//Count: 9  Capacity: 12? 16? random?
            names.Add("Mr Freeze");
            names.Add("Mr Freeze");
            PrintInfo(names);//Count: 11  Capacity: ?
            names.Add("Mr Freeze");
            /*
                CHALLENGE 2:

                    Create a list that stores floats. Call the variable grades.
             
            */
            List<float> grades;//NULL
            //assign a value to grades
            grades = new List<float>();//creating an instance






            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Adding items to a List  ]

                There are 2 ways to add items to a list:
                1) on the initializer. 
                2) using the Add method. 
            */
            List<char> letters = new List<char>() { 'B', 'a', 't', 'm', 'a', 'n' };
            letters.Add('!');

            /*
                CHALLENGE 3:

                    Add a few grades to the grades list you created in CHALLENGE 2.
             
            */
            Random rando = new Random();
            grades.Add(94.5F);
            grades.Add((float)(rando.NextDouble() * 100));
            grades.Add((float)(rando.NextDouble() * 100));
            grades.Add((float)(rando.NextDouble() * 100));
            grades.Add((float)(rando.NextDouble() * 100));
            grades.Add((float)(rando.NextDouble() * 100));
            grades.Add((float)(rando.NextDouble() * 100));





            /*   
                ╔═════════╗ 
                ║ List<T> ║
                ╚═════════╝ 

                [  Looping over a List  ]

                You can loop over a list with a for loop or a foreach loop.
                1) for loop. use the Count property in the for condition.
                2) foreach loop


                Count - how many items have been ADDED
                Capacity - how big (Length) is the internal array

            */
            for (int i = 0; i < letters.Count; i++)
                Console.Write($" {letters[i]}");

            foreach (var letter in letters)
                Console.Write($" {letter}");

            /*
                CHALLENGE 4:

                    1) Fix the Average method of the calculator class to calculate the average of the list parameter.
                    2) Call the Average method on the t1000 variable and pass your grades list to the method.
                    3) print the average that is returned.
             
            */
            float averageGrade = t1000.Average(grades);
            Console.WriteLine("---------GRADES-----------");
            foreach (var grade in grades)
            {
                Console.WriteLine(grade);
            }
            Console.WriteLine($"The average grade: {averageGrade}");


            Console.ReadKey(true);
        }

        private static void PrintInfo(List<string> names)
        {
            // \t is a tab escape sequence
            Console.WriteLine($"Count: {names.Count}\tCapacity: {names.Capacity}");
        }

        private static int AddOne(int localNumber)//pass by value
        {
            return localNumber + 1;
        }


    }

    class Calculator
    {
        public int Sum(int num1, int num2)
        {
            ++num1;
            --num2;//changing these LOCAL variables do NOT affect the variables used when calling the method
            return num1 + num2;
        }


        public float Average(List<float> numbers)
        {
            //loop over the numbers and calculate the average
            float sum = 0F;
            for (int i = 0; i < numbers.Count; i++)
                sum += numbers[i];

            //Linq. Sum()

            return sum / numbers.Count;
        }
    }
}
