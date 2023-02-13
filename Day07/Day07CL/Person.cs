using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07CL
{
    public class Person
    {
        #region Fields
        int _age; //private
        #endregion

        #region Properties
        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 0 && value <= 120)
                    _age = value;
            }
        }
        public string Name { get; private set; } = "Bruce Wayne";

        public JobPosition Position { get; private set; } = JobPosition.Intern;
        #endregion

        #region Constructors
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
        #endregion

        #region Methods
        public void ItsMyBirthday()
        {
            Age++;
            Console.WriteLine($"It's my Birthday!! I'm not {Age} years old. woot! woot! where's the cake?");
        }
        public void Promotion(JobPosition newPosition)
        {
            Position = newPosition;
            switch (Position)
            {
                case JobPosition.Intern:
                    Console.WriteLine("I'm a lowly intern! Let me get you some coffee.");
                    break;
                case JobPosition.JuniorDeveloper:
                    Console.WriteLine("I got a job dad!");
                    break;
                case JobPosition.Developer:
                    Console.WriteLine("I can't believe they promoted me. I've been using ChatGPT the whole time!!");
                    break;
                case JobPosition.SeniorDeveloper:
                    Console.WriteLine("I'm a GOD!!!");
                    break;
                case JobPosition.LeadDeveloper:
                    Console.WriteLine("Just let me do it. Get out of my way!!");
                    break;
                case JobPosition.VicePresident:
                    Console.WriteLine("I forgot everything about programming. Listen to me now!");
                    break;
                case JobPosition.President:
                    Console.WriteLine("Don't talk to me. You are beneath me!");
                    break;
                case JobPosition.CEO:
                    Console.WriteLine("I make 10 million times more than you do. I'm going on vacation.");
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
