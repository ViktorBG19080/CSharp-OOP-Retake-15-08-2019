using SpaceStation.Models.Bags;
using System;
using System.Text;
using SpaceStation.Utilities.Messages;
namespace SpaceStation.Models.Astronauts
{
     class Astronaut : Contracts.IAstronaut
    {
        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public  bool CanBreath => this.Oxygen >0;

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            if (this.Oxygen - 10 < 0)
            {
                this.Oxygen = 0;
            }
            else
                this.Oxygen -= 10;
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");
            sb.AppendLine("Bag items: " + (Bag.Items.Count == 0 ? "none" : string.Join(", ", this.Bag.Items)));
            return sb.ToString().TrimEnd();
        }
    }
}
