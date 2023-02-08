using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Day04
{
    internal class Program
    {
        enum Weapon
        {
            Sword, Axe, Spear, Mace
        }
        static void Main(string[] args)
        {
            /*
                ╔═════════╗ 
                ║Searching║
                ╚═════════╝ 
             
                There are 2 ways to search a list: linear search or binary search
             
                CHALLENGE 1:

                    Convert Linear Search algorithm into a method. 
                        The method should take 2 parameters: list of ints to search, int to search for.
                        The method should return -1 if NOT found or the index if found.
                     
                    The algorithm:
                        1) start at the beginning of the list
                        2) compare each item in the list to the search item
                        3) if found, return the index
                        4) if reach the end of the list, return -1 which means not found
                    
            */



            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 
                
                [  Creating a Dictionary  ]
                
                Dictionary<TKey, TValue>  - the TKey is a placeholder for the type of the keys. TValue is a placeholder for the type of the values.
                
                When you want to create a Dictionary variable, replace TKey with whatever type of data you want to use for the keys and
                replace TValue with the type you want to use for the values.
            */

            Dictionary<Weapon, int> backpack = new Dictionary<Weapon, int>();//will store the counts of each kind of weapon

            //3 ways to add data to a dictionary:
            //  1) initializer.  like a list. new List() {1,2,3,4};
            Dictionary<string, float> menu = new()
            {
                //Key-Value Pair
                //{ key, value }
                { "cheese pizza", 5.99F },
                { "Pepperoni pizza", 7.99F }
            };
            //  2) Add(key, value)
            menu.Add("Veggie Pizza", 9.99F);
            menu.Add("Meat-lovers Pizza", 14.99F);
            try
            {
                menu.Add("Meat-lovers Pizza", 16.99F);//throws an exception!!
            }
            catch (Exception)
            {
                Console.WriteLine("That item is already on the menu.");
            }

            //  3) [key] = value
            menu["Supreme Pizza"] = 12.99F;
            menu["Pineapple Pizza"] = 15.99F;
            menu["Pineapple Pizza"] = 17.99F;//just overwrites the value

            // Ways 1 and 2 could throw an exception
            // IF the key is already in the dictionary

            /*
                CHALLENGE 2:

                    Create a Dictionary that stores names (string) and grades. Call the variable grades.
             
            */

            Dictionary<string, float> grades;

            grades = new Dictionary<string, float>();


            /*  
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Adding items to a Dictionary  ]

                There are 3 ways to add items to a Dictionaruy:
                1) on the initializer. 
                2) using the Add method. 
                3) using [key] = value
            */
            backpack = new Dictionary<Weapon, int>()
            {
                {Weapon.Sword, 5 }
            };
            backpack.Add(Weapon.Axe, 2);
            backpack[Weapon.Spear] = 1;

            /*
                CHALLENGE 3:

                    Add students and grades to your dictionary that you created in CHALLENGE 2.
             
            */
            Random randoFirstBlood = new Random();
            grades.Add("Ramon", GetGrade(randoFirstBlood));
            grades.Add("Elena", GetGrade(randoFirstBlood));
            grades.Add("Cameron", GetGrade(randoFirstBlood));
            grades.Add("Marie", GetGrade(randoFirstBlood));
            grades.Add("Audrey", GetGrade(randoFirstBlood));
            grades.Add("Matthew", GetGrade(randoFirstBlood));

            grades["Ryan"] = GetGrade(randoFirstBlood);
            grades["Logan"] = GetGrade(randoFirstBlood);
            grades["Nicholas"] = GetGrade(randoFirstBlood);
            grades["Anthony"] = GetGrade(randoFirstBlood);

            List<string> names = new List<string>() { "Carlos","Zeyuan","Joanna","Tyler","Damien","Kold","James","Zechariah ","Sephen",
            "Tyler","Elizabeth","Emmanuel","Harlan","Max","Tevin","Evan","Qasim ","fraser","Justin","Logan","Ralzly Kyle","Vijay","Ryan","Mason",
            "Christian","Teondriq","Jalen","Hamilton ","Jai","Nicholas","Jaidon","Gilbert",
            "Jacquelyn","Jennifer","Nicolas","Tyler L","Tyrone","Violet"
            };
            foreach (string name in names)
            {
                grades.TryAdd(name, GetGrade(randoFirstBlood));
            }




            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Looping over a Dictionary  ]

                You should use a foreach loop when needing to loop over the entire dictionary.
               
            */
            foreach (KeyValuePair<Weapon, int> weaponCount in backpack)
                Console.WriteLine($"You have {weaponCount.Value} {weaponCount.Key}");

            Console.WriteLine("Batman's Pies");
            foreach (var menuItem in menu)
            {
                //string item = menuItem.Key;
                //float price = menuItem.Value;
                // ,7  - right aligns in 7 spaces
                // :C2 - formats as a Currency with 2 decimal places
                Console.Write($"{menuItem.Value,7:C2}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($" {menuItem.Key}");
                Console.ResetColor();
            }



            /*
                CHALLENGE 4:

                    Loop over your grades dictionary and print each student name and grade.
             
            */
            Console.WriteLine("----PG2 2302----");
            foreach (var grade in grades)
            {
                Console.ForegroundColor = (grade.Value < 59.5) ? ConsoleColor.Red :
                                          (grade.Value < 69.5) ? ConsoleColor.DarkYellow :
                                          (grade.Value < 79.5) ? ConsoleColor.Yellow :
                                          (grade.Value < 89.5) ? ConsoleColor.Blue :
                                          ConsoleColor.Green;

                Console.Write($"{grade.Value,7:N2}");

                Console.ResetColor();
                Console.WriteLine($"  {grade.Key}");
            }




            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Checking for a key in a Dictionary  ]

                There are 2 ways to see if a key is in the dictionary:
                1) ContainsKey(key)
                2) TryGetValue(key, out value)
               
            */
            if (backpack.ContainsKey(Weapon.Axe))
                Console.WriteLine($"{Weapon.Axe} count: {backpack[Weapon.Axe]}");

            if (backpack.TryGetValue(Weapon.Spear, out int spearCount))
                Console.WriteLine($"{Weapon.Spear} count: {spearCount}");

            string pizza = "Sausage Pizza";
            if (menu.ContainsKey(pizza))
            {
                float cost = menu[pizza];//key-not-found exception!
                Console.WriteLine($"{pizza} cost {cost:C2}.");
            }
            pizza = "Pineapple Pizza";
            if (menu.TryGetValue(pizza, out float pizzaPrice))
            {
                menu[pizza] = pizzaPrice * 1.10F;
                Console.WriteLine($"{pizza} was {pizzaPrice:C2} but now costs {menu[pizza]:C2}. Thanks Putin!!");
            }



            /*
                CHALLENGE 5:

                    Using either of the 2 ways to check for a key, look for a specific student in the dictionary. 
                    If the student is found, print out the student's grade
                    else print out a message that the student was not found
             
            */




            /*   
                ╔══════════════════════════╗ 
                ║ Dictionary<TKey, TValue> ║
                ╚══════════════════════════╝ 

                [  Updating a value for a key in a Dictionary  ]

                To update an exisiting value in the dictionary, use the [ ]
                
               
            */
            backpack[Weapon.Mace] = 0; //sell all maces



            /*
                CHALLENGE 6:

                    Pick any student and curve the grade (add 5) that is stored in the grades dictionary
             
            */
        }

        private static float GetGrade(Random randoFirstBlood)
        {
            return (float)randoFirstBlood.NextDouble() * 100;
        }
    }
}
