using System;

namespace Wizard_Ninja_Samurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard Harry = new Wizard("Harry Potter");
            Ninja Naruto = new Ninja("Naruto");
            Samurai Tom = new Samurai("Tom Cruise");

            Harry.Heal();
            Harry.Heal();
            Harry.Fireball(Tom);
            Naruto.Steal(Harry);
            Tom.DeathBlow(Naruto);
            Naruto.GetAway();
            Tom.Meditate();
        }
    }
}
