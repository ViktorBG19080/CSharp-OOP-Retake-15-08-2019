using System.Linq;
using SpaceStation.Models.Planets;
using System.Collections.Generic;
using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
           foreach (var currentAstronaut in astronauts)
           {
               while(planet.Items.Count>0&&currentAstronaut.CanBreath)
               {
                   var item = planet.Items.ElementAt(0);
                    currentAstronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    currentAstronaut.Breath();
               }

               if(planet.Items.Count==0)
               {
                   break;
               }
           }
        }
    }
}
