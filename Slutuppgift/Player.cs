using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Player
    {
        public int id { get; set; }
        public string name { get; set;}
        public string special { get; set; }
        public string weakness { get; set; }
        public int motivation;

        public Player(int Id, string Name, string Special, string Weakness)
        {
            id = Id;
            name = Name;
            special = Special;
            weakness = Weakness;
        }
    }
}
