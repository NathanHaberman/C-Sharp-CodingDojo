using System;

namespace Wizard_Ninja_Samurai{
    public class Wizard : Human{
        public Wizard(string wizardName) : base(wizardName){
            intelligence = 25;
            health = 50;
        }
        public void Heal(){
            int amount = intelligence * 10;
            health += amount;
            System.Console.WriteLine("{0} heals for {1} HP and now has {2} HP!! This game is horribly unbalanced!", name, amount, health);
        }
        public void Fireball(Human enemy){
            Random rand = new Random();
            int damage = rand.Next(20,51);
            enemy.health -= damage;
        }
    }
}