using System;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut:IAstronaut
    {
        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }
        public string Name 
        {
             get=>this.name;
             set
             {
                 if(string.IsNullOrWhiteSpace(value))
                 {
                     throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                 }
                 this.name = value;
             }
        }
        public double Oxygen 
        { 
            get =>this.oxygen;
            set
            {
                if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath =>this.Oxygen>0;

        public IBag Bag { get; }

        public virtual void Breath()
        {
            this.Oxygen = this.Oxygen - 10 < 0 ? 0 : this.Oxygen - 10;
        }
    } 
}
