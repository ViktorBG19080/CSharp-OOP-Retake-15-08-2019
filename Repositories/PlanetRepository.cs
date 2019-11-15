using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models;
        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();

        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.Find(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            var planetToRemove  = models.FirstOrDefault(x=>x.Name == model.Name);
           if(model !=null)
           {
               models.Remove(planetToRemove);
               return true;
           }
           return false;
        }
    }
}
