using System.Collections.Generic;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> astronautRepository;
        
        public AstronautRepository()
        {
            astronautRepository = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => astronautRepository;

        public void Add(IAstronaut astronaut)
        {
            astronautRepository.Add(astronaut);
        }

        public IAstronaut FindByName(string astronautName)
        {
            IAstronaut astronaut = null;
            foreach (var model in Models)
            {
                if(astronautName == model.Name)
                {
                    astronaut = model;
                }
            }

            return astronaut;
        }

        public bool Remove(IAstronaut astronaut)
        {
           var target = this.FindByName(astronaut.Name);
           if(target==null)
           {
               return false;
           }
           this.astronautRepository.Remove(target);
           return true;
        }
    }
}

