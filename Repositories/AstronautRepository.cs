using System.Linq;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Repositories
{
    class AstronautRepository : IRepository<IAstronaut>
    {

        private List<IAstronaut> models;
        public AstronautRepository()
        {
            models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models { get => this.models.AsReadOnly(); }

        public void Add(IAstronaut model)
        {
            this.models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
           var astronautToRemove  = models.FirstOrDefault(x=>x.Name == model.Name);
           if(model !=null)
           {
               models.Remove(astronautToRemove);
               return true;
           }
           return false;
        }
    }
}
