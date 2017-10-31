using System;

namespace Wizard_Ninja_Samurai{
    public class Ninja : Human{
        public Ninja(string ninjaName) : base(ninjaName){
            dexterity = 175;
        }
        public void Steal(Human enemy){
            Attack(enemy);
            health += 15;
            System.Console.WriteLine("{0} stole from {1}, and healed 15 HP! Play a Wizard next time, they are like gods!", name, enemy.name);
        }
        public void GetAway(){
            health -= 15;
            System.Console.WriteLine("{0} is confused... {0} hurt itself", name);
        }
    }
}