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
        public ICollection<string> Items { get => items.AsReadOnly();}
        public void AddItem(string item) =>items.Add(item);
    }
}
