using Day08CL;

namespace Day08
{
    /*                    DERIVING CLASSESS          
                                                               
                                ╔═════════╗     ╔══════════╗ 
                 public  class  ║SomeClass║  :  ║OtherClass║ 
                                ╚═════════╝     ╚══════════╝
                                     │                │         
                                     └──┐             └──┐             
                                   ┌────▼────┐      ┌────▼────┐      
                                   │ Derived │      │  Base   │    
                                   │  Class  │      │  Class  │     
                                   └─────────┘      └─────────┘     

    
                CONSTRUCTORS: the derived constructor must call a base constructor
                public SomeClass(.....) : base(....)


     */
    internal class Program
    {
        static void Main(string[] args)
        {
            GameObject gObject = new GameObject(5, 10);

            /*
                CHALLENGE 1:

                    In the Day08CL project, add a new class, Pistol, that derives from Weapon.
                    Pistol should have properties for Rounds and MagCapacity.
                    Add a constructor that calls the base constructor
             
            */
            //Weapon pewpew = new Weapon(500,100);
            Pistol glock = new Pistol(10, 10, 1000, 50);





            /*  
                ╔═══════════╗ 
                ║ UPCASTING ║ - converting a derived type variable to a base type variable
                ╚═══════════╝ 
                
                This is ALWAYS safe.

                DerivedType A = new DerivedType();
                BaseType B = A;
            



                CHALLENGE 2:
                    Create a List of Weapon. Create several Pistols and add them to the list of weapons.
            */

            int num = 5;//4 bytes
            //IMPLICIT casting
            long bigNum = num;//8 bytes

            //EXPLICIT casting
            num = (int)bigNum;


            //UPCASTING
            // ALWAYS SAFE
            //from a DERIVED type to a BASE type
            Weapon equipped = glock;
            Console.WriteLine(glock.Rounds);
            //Console.WriteLine(equipped.Rounds);

            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(glock);//upcasted to Weapon
            weapons.Add(new Knife(3, 10));//upcasted to Weapon

            //equipped = new Knife(3, 10);

            /*  
                ╔═════════════╗ 
                ║ DOWNCASTING ║ - converting a base type variable to a derived type variable
                ╚═════════════╝ 
                
                This is NOT SAFE!!!!!

            
                BaseType B = new DerivedType(); //upcasting
                DerivedType A = B; !! Build ERROR !!
            

                3 ways to downcast safely...
                1) explicit cast inside of a try-catch
                    try {  DerivedType A = B;  }
                    catch(Exception) { }

                2) use the 'as' keyword
                    NOTE: null will be assigned to A if B cannot be cast to DerivedType
                    DerivedType A = B as DerivedType;
                    if(A != null) { can use A }

                3) use 'is' in pattern matching
                    if(B is DerivedType A) { can use A }



                CHALLENGE 3:
                    Loop over the list of weapons.
                    Call ShowMe on each weapon.
                    Downcast to a Pistol and print the rounds and mag capacity of each pistol
            */
            try
            {
                Knife knife = (Knife)equipped;
            }
            catch (Exception)
            {
            }
            //'as' keyword
            //will assign NULL to blade if equipped is NOT a knife
            Knife blade = equipped as Knife;
            if(blade != null)
                Console.WriteLine(blade.Length);

            //'is' keyword. pattern matching.
            if(equipped is Knife hunting)
                Console.WriteLine(hunting.Length);

            foreach (Weapon weapon in weapons)
            {
                weapon.ShowMe();

                //if (weapon is Pistol bang)
                //    Console.WriteLine($"Rounds: {bang.Rounds} Mag Capacity: {bang.MagCapacity}");
                //else if(weapon is Knife cutter)
                //    Console.WriteLine($"Length of the blade: {cutter.Length}");
            }


            /*  
                ╔═════════════╗ 
                ║ OVERRIDING  ║ - changing the behavior of a base method
                ╚═════════════╝ 
                
                2 things are required to override a base method:
                1) add 'virtual' to the base method
                2) add a method to the derived class that has the same signature as the base. put 'override' to the derived method


                FULLY OVERRIDING:
                    not calling the base method from the derived method

                EXTENDING:
                    calling the base method from the derived method




                CHALLENGE 4:
                    Override Weapon's ShowMe method in the Pistol class.
                    In Pistol's version, 
                        call the base version and print out the rounds and magCapacity
            */
            Player playa = new Player('$', 5, 5);
            object someGameObject = playa;
            Console.WriteLine(someGameObject);
        }
    }
}