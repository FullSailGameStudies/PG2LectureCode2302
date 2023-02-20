using Newtonsoft.Json;
using System.Text;

namespace Day10
{
    //Masking, & (Ands) | (Ors)
    enum Powers
    {
        Money = 1, Flight = 2, LazerEyes = 4, Strength = 8, Speed = 16, Swimming = 32
    }

    class Superhero
    {
        public string Name { get; set; }
        public string Secret { get; set; }
        public Powers SuperPower { get; set; }
    }

    /*
        ╔══════════╗ 
        ║ File I/O ║
        ╚══════════╝ 

        3 things are required for File I/O:
        1) Open the file
        2) read/write to the file
        3) close the file


        TIPS:
            use File.ReadAllText to open,read,close the file in 1 statement
            the using() statement can ensure that the file is closed

    */
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                ╔══════════╗ 
                ║ File I/O ║
                ╚══════════╝ 

                [  Open the file  ]
                [  Write to the file  ]
                [  Close the file  ]
             
                you need the path to the file
                    use full path ( drive + directories + filename )
                    or use relative path ( directories + filename )
                    or current directory ( filename )


                
                using (StreamWriter sw = new StreamWriter(filePath)) // this line opens the file to write to it
                {                
                    //these lines write to the file
                    sw.Write("Batman");
                    sw.Write(54);
                    sw.Write(13.7);
                    sw.Write(true);

                }//this closes the file

            */

            string directories = @"C:\temp\2302"; //use @ in front of the string to ignore escape sequences inside the string
            string fileName = "tempFile.txt";
            string filePath = Path.Combine(directories, fileName); //use Path.Combine to get the proper directory separators

            char delimiter = '\n';
            //1. Open the file
            using (StreamWriter sw = new StreamWriter(filePath)) //IDisposable
            {
                //2. write to the file
                sw.Write("Batman is the best!");
                sw.Write(delimiter);
                sw.Write(5);
                sw.Write(delimiter);
                sw.Write(420.13);
                sw.Write(delimiter);
                sw.Write(true);
            }//3. CLOSE THE FILE!  } will call Dispose() on the sw which will call Close on the file



            /*
                ╔═══════════════════╗ 
                ║ Splitting Strings ║
                ╚═══════════════════╝ 

                taking 1 string a separating it into multiple pieces of data

                use the string's Split method

            */
            string csvString = "Batman;Bruce Wayne;;;Bats;The Dark Knight&&Joker&Riddler&Bane&Aquaman";
            string[] data = csvString.Split(new char[] { ';', '&' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }

            /*
                CHALLENGE 1:

                    read the data in from the file above and split the line to get the data
             
            */

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while( (line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }


            Console.ReadKey();

            string csvData = File.ReadAllText("data2.csv");//OPENS, READS, CLOSES the file
            string[] csvLines = csvData.Split(new char[] { '%'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in csvLines)
            {
                string[] chars = line.Split('<');
                foreach (string c in chars)
                    Console.Write(c);
                Console.WriteLine();
            }
            //StringBuilder sb = new StringBuilder();
            //bool isFirst = true;
            //bool isFirstLine = true;
            //foreach (var line in csvLines)
            //{
            //    Console.WriteLine(line);

            //    if (!isFirstLine)
            //        sb.Append('%');
            //    foreach (var c in line)
            //    {
            //        if (!isFirst)
            //            sb.Append('<');
            //        sb.Append(c);
            //        isFirst = false;
            //    }
            //    isFirstLine = false;
            //}
            //File.WriteAllText("data2.csv", sb.ToString());


            /*
                ╔═════════════╗ 
                ║ Serializing ║
                ╚═════════════╝ 

                Saving the state (data) of objects

            */

            List<Superhero> JLA = new List<Superhero>();
            JLA.Add(new Superhero() { Name = "Batman", Secret = "Bruce Wayne", SuperPower = Powers.Money });
            JLA.Add(new Superhero() { Name = "Superman", Secret = "Clark Kent", SuperPower = Powers.Flight | Powers.LazerEyes });
            JLA.Add(new Superhero() { Name = "Wonder Woman", Secret = "Diana Prince", SuperPower = Powers.Strength });
            JLA.Add(new Superhero() { Name = "Flash", Secret = "Barry Allen", SuperPower = Powers.Speed });
            JLA.Add(new Superhero() { Name = "Aquaman", Secret = "Arthur Curry", SuperPower = Powers.Swimming });

            //SERIALIZE the state (data) of my objects
            string newFilePath = Path.ChangeExtension(filePath, ".json");
            using (StreamWriter sw = new StreamWriter(newFilePath))
            {
                using (JsonTextWriter jtw = new JsonTextWriter(sw))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(jtw, JLA);
                }
            }

            //OR
            File.WriteAllText(newFilePath, JsonConvert.SerializeObject(JLA, Formatting.Indented));


            /*
                ╔═══════════════╗ 
                ║ Deserializing ║
                ╚═══════════════╝ 

                Recreating the objects from the saved state (data) of objects

            */

        }
    }
}