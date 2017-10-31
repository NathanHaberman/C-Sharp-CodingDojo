namespace Wizard_Ninja_Samurai{
    public class Samurai : Human{
        public Samurai(string samuraiName) : base(samuraiName){
            health = 200;
        }
        public void DeathBlow(Human enemy){
            if (enemy.health <= 50){
                enemy.health = 0;
                System.Console.WriteLine("{0} performed a death blow to {1}! It was super effective!", name, enemy.name);
            } else {
                System.Console.WriteLine("{0} performed a death bl... Wait, oh sorry, never mind, {0} actually did nothing", name);
            }
        }
        public void Meditate(){
            health = 200;
            System.Console.WriteLine("{0} is back to full health, too bad {0} isn't a Wizard... Those Wizards are overpowered...", name);
        }
    }
}