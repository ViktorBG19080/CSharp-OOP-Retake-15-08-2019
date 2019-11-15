using System;
using System.Collections.Generic;
using SpaceStation.Utilities.Messages;
using System.Text;

namespace SpaceStation.Models.Planets
{
    class Planet : IPlanet
    {
        private string name;
        public Planet(string name)
        {
            this.Name = name;
            this.Items = new List<string>();
        }
        public ICollection<string> Items { get;}

        public string Name
        {
            get=>name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

    }
}
