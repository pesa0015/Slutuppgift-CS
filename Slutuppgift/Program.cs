using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Program
    {
        public static Player myCharacter = new Player();
        public static Player myEnemy = new Player();
        public static Place thePlace = new Place();
        public static Random nr = new Random();
        public static Player winner = new Player();

        static void Main(string[] args)
        {
            myCharacter.chosen = false;
            myEnemy.chosen = false;
            thePlace.chosen = false;

            while (myCharacter.chosen == false)
            {
                ChooseOrRandom("Vill du välja eller slumpa en karaktär? (välja/slumpa)");
            }

            while (myEnemy.chosen == false)
            {
                ChooseOrRandom("Vill du välja eller slumpa en fiende? (välja/slumpa)");
            }

            while (thePlace.chosen == false)
            {
                ChooseOrRandom("Vill du välja eller slumpa en plats? (välja/slumpa)");
            }

            myCharacter.hp = nr.Next(50, 100);
            myEnemy.hp = nr.Next(50, 100);

            Console.WriteLine("PREPARE FOR BATTLE");
            Console.WriteLine();
            Console.WriteLine(myCharacter.name.ToUpper() + " " + myCharacter.hp + " hp vs. " + myEnemy.name.ToUpper() + " " + myEnemy.hp + " hp");
            Console.WriteLine();

            Console.WriteLine("Vill du se hela striden? (ja/nej)");
            string showDamages = Console.ReadLine();

            while (showDamages.ToLower() != "ja" && showDamages.ToLower() != "nej")
            {
                Console.WriteLine("Ogiltigt svar.");
                showDamages = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine("Tryck Enter för att börja!");

            string result = Console.ReadKey().Key.ToString();

            while (result != "Enter")
            {
                Console.WriteLine();
                Console.WriteLine("Det här var inte bra. Tryck ENTER för att börja!");
                result = Console.ReadKey().Key.ToString();
            }

            if (result == "Enter")
            {
                for (int i = 0; i <= 5; i++)
                {
                    myCharacter.damage = nr.Next(1, 10);
                    myEnemy.damage = nr.Next(1, 10);

                    myCharacter.hp = myCharacter.hp - myEnemy.damage;
                    myEnemy.hp = myEnemy.hp - myCharacter.damage;

                    if (showDamages.ToLower() == "ja")
                    {
                        Console.WriteLine();
                        Console.WriteLine(myCharacter.name.ToUpper() + " " + myCharacter.hp + " hp (-" + myEnemy.damage + ")");
                        Console.WriteLine(myEnemy.name.ToUpper() + " " + myEnemy.hp + " hp (-" + myCharacter.damage + ")");
                        Console.WriteLine();
                    }

                    if (myCharacter.hp > myEnemy.hp)
                    {
                        winner.winner = myCharacter.name;
                        winner.hp = myCharacter.hp;
                    }

                    else if (myCharacter.hp < myEnemy.hp)
                    {
                        winner.winner = myEnemy.name;
                        winner.hp = myEnemy.hp;
                    }
                }

                Console.WriteLine();
                Console.WriteLine("WINNER: " + winner.winner + " (" + winner.hp + " hp left)");
            }
        }

        static void ChooseOrRandom(string question)
        {
            List<Player> GoodCharacters = new List<Player>();
            GoodCharacters.Add(new Player(1, "Batman"));
            GoodCharacters.Add(new Player(2, "Superman"));
            GoodCharacters.Add(new Player(3, "Tyrion"));
            GoodCharacters.Add(new Player(4, "John McClane"));
            GoodCharacters.Add(new Player(5, "Bryan Mills"));
            GoodCharacters.Add(new Player(6, "Oskar"));

            List<Player> EvilCharacters = new List<Player>();
            EvilCharacters.Add(new Player(1, "saurin"));
            EvilCharacters.Add(new Player(2, "Frankenstein"));
            EvilCharacters.Add(new Player(3, "Voldemort"));
            EvilCharacters.Add(new Player(4, "Godzilla"));
            EvilCharacters.Add(new Player(5, "King Joffrey"));
            EvilCharacters.Add(new Player(6, "Joker"));

            List<Place> Places = new List<Place>();
            Places.Add(new Place(1, "Mount Everest"));
            Places.Add(new Place(2, "Skolans tak"));
            Places.Add(new Place(3, "London"));
            Places.Add(new Place(4, "Dubai"));
            Places.Add(new Place(5, "Paris"));
            Places.Add(new Place(6, "New York"));

            Console.WriteLine(question);
            string chooseOrRandom = Console.ReadLine();

            if (chooseOrRandom.ToLower() == "välja")
            {
                if (myCharacter.chosen == false)
                {
                    myCharacter.ListCharacters(GoodCharacters);

                    Message("Välj nr.");

                    int result;

                    while (myCharacter.chosen == false)
                    {
                        var IdOfChosenCharacter = Console.ReadLine();
                        
                        result = CheckInt(IdOfChosenCharacter);

                        if (result > 0)
                        {
                            myCharacter.id = myCharacter.GetId(GoodCharacters, result);

                            if (myCharacter.id == 0)
                            {
                                Message("Karaktären finns inte, försök igen.");
                            }
                            else
                            {
                                myCharacter.name = myCharacter.GetName(GoodCharacters, myCharacter.id);

                                myCharacter.chosen = true;

                                Console.WriteLine();
                                Console.WriteLine(myCharacter.name);
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Message("Ogiltigt svar.");
                        }
                    }
                }

                else if (myEnemy.chosen == false)
                {
                    myEnemy.ListCharacters(EvilCharacters);

                    Message("Välj nr.");

                    int result;

                    while (myEnemy.chosen == false)
                    {
                        var IdOfChosenCharacter = Console.ReadLine();

                        result = CheckInt(IdOfChosenCharacter);

                        if (result > 0)
                        {
                            myEnemy.id = myEnemy.GetId(EvilCharacters, result);

                            if (myEnemy.id == 0)
                            {
                                Message("Fienden finns inte, försök igen.");
                            }

                            else
                            {
                                myEnemy.name = myEnemy.GetName(EvilCharacters, myEnemy.id);

                                myEnemy.chosen = true;

                                Console.WriteLine();
                                Console.WriteLine(myEnemy.name);
                                Console.WriteLine();
                            }
                        }
                        
                        else
                        {
                            Message("Ogiltigt svar.");
                        }
                    }
                }

                else if (thePlace.chosen == false)
                {
                    thePlace.ListPlaces(Places);

                    Message("Välj nr.");

                    int result;

                    while (thePlace.chosen == false)
                    {
                        var IdOfChosenPlace = Console.ReadLine();

                        result = CheckInt(IdOfChosenPlace);

                        if (result > 0)
                        {
                            thePlace.id = thePlace.GetId(Places, result);

                            if (thePlace.id == 0)
                            {
                                Message("Platsen finns inte, försök igen.");
                            }
                            else
                            {
                                thePlace.name = thePlace.GetName(Places, thePlace.id);

                                thePlace.chosen = true;

                                Console.WriteLine();
                                Console.WriteLine(thePlace.name);
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Message("Ogiltigt svar.");
                        }
                    }
                }
            }

            else if (chooseOrRandom.ToLower() == "slumpa")
            {
                if (myCharacter.chosen == false)
                {
                    int id = nr.Next(0, GoodCharacters.Count);
                    myCharacter.id = id;
                    myCharacter.name = GoodCharacters[id].name;
                    myCharacter.chosen = true;
                    Console.WriteLine();
                    Console.WriteLine(myCharacter.name);
                    Console.WriteLine();
                }

                else if (myEnemy.chosen == false)
                {
                    int id = nr.Next(0, EvilCharacters.Count);
                    myEnemy.id = id;
                    myEnemy.name = EvilCharacters[id].name;
                    myEnemy.chosen = true;
                    Console.WriteLine();
                    Console.WriteLine(myEnemy.name);
                    Console.WriteLine();
                }

                else if (thePlace.chosen == false)
                {
                    int id = nr.Next(0, Places.Count);
                    thePlace.id = id;
                    thePlace.name = Places[id].name;
                    thePlace.chosen = true;
                    Console.WriteLine();
                    Console.WriteLine(thePlace.name);
                    Console.WriteLine();
                }
            }

            else
            {
                Console.Clear();
                Console.WriteLine("Felaktigt svar.");
                Console.WriteLine();
            }
        }

        static int CheckInt(string answer)
        {
            int IdOfCharacter;

            bool result = Int32.TryParse(answer, out IdOfCharacter);

            if (result)
            {
                return IdOfCharacter;
            }
            else
            {
                return 0;
            }
        }

        static void Message(string message)
        {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}
