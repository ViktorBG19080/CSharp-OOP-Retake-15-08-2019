using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        public Backpack()
        {
            Items = new  List<string>();
        }
        public ICollection<string> Items {get;}
    }
}
