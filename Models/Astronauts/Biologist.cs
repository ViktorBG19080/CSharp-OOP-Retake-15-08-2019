
namespace SpaceStation.Models.Astronauts
{
    public class Biologist:Astronaut
    {
        private const double initialOxygen = 70;
        private const double oxygenDecrement = 5;
        public Biologist(string name):base(name,initialOxygen)
        {
            
        }
        public override void Breath()
        {
            this.Oxygen = this.Oxygen-oxygenDecrement<0?0:this.Oxygen-oxygenDecrement;
        }
    }
}
