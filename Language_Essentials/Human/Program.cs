using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanClass person1 = new HumanClass("Nathan");
            HumanClass person2 = new HumanClass("Tyler");
            person1.Attack(person2);
            person1.Attack(person2);
        }
    }
}
