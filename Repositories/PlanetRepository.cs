using SpaceStation.Models.Planets;
using System.Collections.Generic;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository:IRepository<IPlanet>
    {

        private List<IPlanet> planetRepository;
        public PlanetRepository()
        {
            planetRepository = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => planetRepository;

        public void Add(IPlanet planet)
        {
            planetRepository.Add(planet);
        }

        public IPlanet FindByName(string name)
        {
            IPlanet planet = null;
            foreach (var model in Models)
            {
                if(name == model.Name)
                {
                    planet = model;
                }
            }

            return planet;
        }

        public bool Remove(IPlanet planet)
        {
            var target = this.FindByName(planet.Name);
            if(target==null)
            {
                return false;
            }
            this.planetRepository.Remove(target);
            return true;
        }
    }
}
