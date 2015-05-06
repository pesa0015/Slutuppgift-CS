using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutuppgift
{
    class Place
    {
        public int id { get; set; }
        public string name { get; set;}
        public bool chosen { get; set; }

        public Place(int Id, string Name)
        {
            id = Id;
            name = Name;
        }

        public Place()
        {

        }

        public void ListPlaces(List<Place> Places)
        {
            Console.WriteLine("Id | Namn");
            Console.WriteLine();
            foreach (var place in Places)
            {
                Console.WriteLine(place.id + " " + place.name);
            }
            
        }

        public int GetId(List<Place> Places, int Id)
        {
            int place = Places.Where(a => a.id == Id)
                             .Select(a => a.id)
                             .FirstOrDefault();

            return place;
        }

        public string GetName(List<Place> Places, int IdOfTheChosenPlace)
        {
            string place = Places.Where(a => a.id == IdOfTheChosenPlace)
                             .Select(a => a.name )
                             .FirstOrDefault();

            return place;
        }
    }
}
