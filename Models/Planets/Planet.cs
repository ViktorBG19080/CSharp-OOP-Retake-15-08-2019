using System;
using SpaceStation.Utilities.Messages;
using System.Collections.Generic;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private List<string> items;
        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }
        public ICollection<string> Items {get=>items.AsReadOnly();}

        public string Name 
        {
            get => this.name;
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw  new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public void AddItem(string itemName)
        {
            items.Add(itemName);
        }

        public string RemoveItem()
        {
            var result = items[0];
            items.RemoveAt(0);
            return result;
        }
    }
}
