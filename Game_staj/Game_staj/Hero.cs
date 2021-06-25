using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_staj
{
    abstract class Hero
    {
        protected static Random rand = new Random();

        private int health;

        public int Health
        {
            get
            {
                return health;
            }

            private set
            {
                health = value;
            }
        }

        private int armor;
        public int Armor
        {
            get
            {
                return armor;
            }

            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("armor", "Armor cannot be negative");
                armor = value;
            }
        }

        private int damage;
        public int Damage
        {
            get
            {
                return damage;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("damage", "Damage cannot be negative.");
                }
                damage = value;
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == "")
                    throw new ArgumentOutOfRangeException("name", "Name cannot be empty");
                name = value;
            }
        }

        public Hero(string name, int health, int armor, int damage)
        {
            Name = name;
            if (health <= 0)
                throw new ArgumentOutOfRangeException("health", "Cannot create a dead hero!");
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public bool IsAlive()
        {
            return health > 0;
        }

        public virtual int Attack()
        {
            double multiplier = rand.Next(80, 121);
            return Convert.ToInt32(Damage * (multiplier / 100.0));
        }

        public virtual int Defend(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException("damage", "Cannot attack with negative damage");
            }

            double multiplier = rand.Next(80, 121);
            int howMuchToReduce = Convert.ToInt32(Armor * (multiplier / 100));

            int damageReduced = damage - howMuchToReduce;
            if (damageReduced < 0)
                return 0;

            Health = Health - damageReduced;
            return damageReduced;
        }
    }
}
