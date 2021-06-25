using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_staj
{
    class Assassin : Hero
    {
        public Assassin(string name, int health, int armor, int damage) : base(name, health, armor, damage)
        {
        }

        public override int Attack()
        {
            int baseDamage = base.Attack();

            double probability = rand.NextDouble();
            if (probability < 0.35)
            {
                return baseDamage * 3;
            }
            return baseDamage;
        }
    }
}
