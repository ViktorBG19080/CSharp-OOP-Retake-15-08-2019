using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private readonly List<string> items;
        public Backpack()
        {
            items = new  List<string>();
        }
        public ICollection<string> Items { get => items; }

        public override string ToString()
        {
            return "Bag items: " + (items.Count == 0 ? "none" : string.Join(", ", items));
        }
    }
}
