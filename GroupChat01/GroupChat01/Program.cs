namespace GroupChat01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int myFave = GetFavoriteNumber(true);

            Console.WriteLine($"My favorite number is {myFave}");
        }

        //method signature parts:
        //access modifiers: public/private/protected/static
        //return type: int
        //name: GetFavoriteNumber
        //parameter: makeEven
        static int GetFavoriteNumber(bool makeEven)
        {
            Random randy = new Random();
            int num = randy.Next(100);
            if (makeEven == true && num % 2 != 0)
                num++;

            return num;
        }//num is ONLY visible in GetFavoriteNumber
    }
}