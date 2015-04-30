using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Enemy
    {
        public int id { get; set; }
        public string name { get; set;}
        public string special { get; set; }
        public string weakness { get; set; }
        public int motivation;

        public Enemy(int Id, string Name, string Special, string Weakness)
        {
            id = Id;
            name = Name;
            special = Special;
            weakness = Weakness;
        }
    }
}
