using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_staj
{
    class Knight : Hero
    {
        public Knight(string name, int health, int armor, int damage) : base(name, health, armor, damage)
        {

        }

        public override int Attack()
        {
            int baseDamage = base.Attack();

            double probability = rand.NextDouble();
            if (probability < 0.1)
            {
                // 10% chance to execute this code
                return baseDamage * 2;
            }
            return baseDamage;
        }

        public override int Defend(int damage)
        {
            double probability = rand.NextDouble();
            if (probability < 0.2)
            {
                return base.Defend(0);
            }
            else
            {
                return base.Defend(damage);
            }
        }
    }
}
