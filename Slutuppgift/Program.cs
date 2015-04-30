using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> GoodCharacters = new List<Player>();
            GoodCharacters.Add(new Player(0, "Batman", "", ""));
            GoodCharacters.Add(new Player(1, "Superman", "", ""));
            GoodCharacters.Add(new Player(2, "Tyrion", "", ""));
            GoodCharacters.Add(new Player(3, "John McClane", "", ""));
            GoodCharacters.Add(new Player(4, "Bryan Mills", "", ""));
            GoodCharacters.Add(new Player(5, "Oskar", "", ""));

            List<Enemy> EvilCharacters = new List<Enemy>();
            EvilCharacters.Add(new Enemy(0, "saurin", "", ""));
            EvilCharacters.Add(new Enemy(1, "Frankenstein", "", ""));
            EvilCharacters.Add(new Enemy(2, "Voldemort", "", ""));
            EvilCharacters.Add(new Enemy(3, "Godzilla", "", ""));
            EvilCharacters.Add(new Enemy(4, "King Joffrey", "", ""));
            EvilCharacters.Add(new Enemy(5, "Joker", "", ""));

            Console.WriteLine("Vill du välja eller slumpa en karaktär?");
            var chooseOrRandom = Console.ReadLine();

            if (chooseOrRandom != "välja" && chooseOrRandom != "slumpa")
            {
                Console.WriteLine("Felaktigt svar. Svara 'välja' eller 'slumpa'!");
                chooseOrRandom = Console.ReadLine();
            }

            if (chooseOrRandom == "välja")
            {
                Console.WriteLine("Id | Namn");
                Console.WriteLine();
                foreach(var character in GoodCharacters)
                {
                     Console.WriteLine(character.id + " " + character.name);
                }

                var IdOfChosenGoodCharacter = Console.ReadLine();

                int ChosenGoodCharacter = int.Parse(IdOfChosenGoodCharacter);

                var NameOfGoodCharacter = GoodCharacters.Where(a => a.id == ChosenGoodCharacter)
                     .Select(a => a.name)
                     .First();

                var IdOfGoodCharacter = GoodCharacters.Where(a => a.id == ChosenGoodCharacter)
                     .Select(a => a.id)
                     .First();

                Console.Clear();
                Console.WriteLine(IdOfGoodCharacter + " " + NameOfGoodCharacter);
            }

            if (chooseOrRandom == "slumpa")
            {
                Random nr = new Random();
                int id = nr.Next(0, GoodCharacters.Count);
                Console.WriteLine(id + " " + GoodCharacters[id].name);
            }

            //string aName = Characters.OrderBy(s => Guid.NewGuid()).First();

            //var Goliat = new Player("Goliat", "Extra power", "Slow");
            //var place = new Place();
            //Console.WriteLine(Goliat.name + " "  + Goliat.special + " " + Goliat.weakness);
            //Console.WriteLine(place.name);

            /*

            //string[] Characters = { "A", "B", "C", "D", "E", "F", "G", "H" };
            foreach (var Character in Characters)
            {
                Console.WriteLine(Character.name);
            }
            
            */

        }
    }
}
