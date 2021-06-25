using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_staj
{
    class NotificationArgs
    {
        public Hero Attacker { get; set; }
        public int Attack { get; set; }
        public Hero Defender { get; set; }
        public int Damage { get; set; }
    }
    interface IGameNotification
    {
        void NotifyGameProgress(NotificationArgs args);
    }
}
