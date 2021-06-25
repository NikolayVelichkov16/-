using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_staj
{
    delegate void NotifyDelegate(NotificationArgs args);

    class GameEngine
    {
        public Hero Winner { get; set; }
        public Hero HeroX { get; set; }
        public Hero HeroY { get; set; }

        public IGameNotification Notifications { get; set; }

        public NotifyDelegate Notify { get; set; }

        public GameEngine(Hero heroX, Hero heroY)
        {
            HeroX = heroX;
            HeroY = heroY;
        }

        public void Fight()
        {
            Hero attacker = HeroX;
            Hero defender = HeroY;

            while (attacker.IsAlive())
            {
                int attack = attacker.Attack();
                int damage = defender.Defend(attack);

                //Notifications?.NotifyGameProgress(
                //    new NotificationArgs
                //    {
                //        Attacker = attacker,
                //        Attack = attack,
                //        Defender = defender,
                //        Damage = damage
                //    }); 
                if (Notify != null)
                {
                    Notify(
                        new NotificationArgs
                        {
                            Attacker = attacker,
                            Attack = attack,
                            Defender = defender,
                            Damage = damage
                        });
                }

                Hero temp = attacker;
                attacker = defender;
                defender = temp;
            }
            if (HeroX.IsAlive())
                Winner = HeroX;
            else
                Winner = HeroY;
        }
    }
}
