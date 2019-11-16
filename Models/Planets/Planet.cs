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
        public ICollection<string> Items {get=>items;}

        public string Name 
        {
            get => this.name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw  new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }
    }
}
