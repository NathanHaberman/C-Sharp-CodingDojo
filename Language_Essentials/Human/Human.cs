namespace Human{
    public class HumanClass{
        public string name {get; set;}
        public int strength {get; set;}
        public int intelligence {get; set;}
        public int dexterity {get; set;}
        public int health {get; set;}
        public HumanClass(string newName, int str = 3, int intel = 3, int dex = 3, int hp = 100){
            name = newName;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }

        public void Attack(HumanClass instance){
            instance.health -= strength * 5;
            System.Console.WriteLine("{0} attacked {1} and their health is now {2}", name, instance.name, instance.health);
        }
    }
}