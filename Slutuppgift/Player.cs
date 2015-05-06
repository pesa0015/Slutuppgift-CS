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
        public bool chosen { get; set; }
        public int hp { get; set; }
        public int damage { get; set; }
        public string winner { get; set; }

        public Player(int Id, string Name)
        {
            id = Id;
            name = Name;
        }

        public Player()
        {

        }

        public void ListCharacters(List<Player> Characters)
        {
            Console.WriteLine("Id | Namn");
            Console.WriteLine();
            foreach (var character in Characters)
            {
                Console.WriteLine(character.id + " " + character.name);
            }
            
        }

        public int GetId(List<Player> Characters, int Id)
        {
            int Character = Characters.Where(a => a.id == Id)
                             .Select(a => a.id)
                             .FirstOrDefault();

            return Character;
        }
        
        public string GetName(List<Player> Characters, int IdOfTheChosenCharacter)
        {
            string Character = Characters.Where(a => a.id == IdOfTheChosenCharacter)
                             .Select(a => a.name )
                             .FirstOrDefault();

            return Character;
        }
    }
}
