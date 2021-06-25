using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_staj
{
    class ConsoleNotification : IGameNotification
    {
        public void NotifyGameProgress(NotificationArgs args)
        {
            Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {args.Attack} and scored {args.Damage}");
        }
    }

    class Program
    {
        static void ConsoleNotify(NotificationArgs args)
        {
            Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {args.Attack} and scored {args.Damage}");
        }

        static void Main(string[] args)
        {

            Hero knight = new Knight("Knight", 100, 50, 30);
            Hero assassin = new Assassin("Assassin", 100, 30, 20);

            GameEngine gameEngine = new GameEngine(knight, assassin);
            // With Interfaces
            //gameEngine.Notifications = new ConsoleNotification();

            // With delegate
            //gameEngine.Notify = ConsoleNotify;
            //gameEngine.Notify = (args) => Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {args.Attack} and scored {args.Damage}");
            gameEngine.Notify = delegate (NotificationArgs args)
            {
                Console.WriteLine($"{args.Attacker.Name} attacked {args.Defender.Name} with {args.Attack} and scored {args.Damage}");
            };

            Console.WriteLine("The fight begins...");
            gameEngine.Fight();
            Console.WriteLine("And the winner is " + gameEngine.Winner.Name);

            Console.ReadLine();
        }
    }
}
