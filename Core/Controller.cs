using System;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System.Text;
using System.Linq;

namespace SpaceStation.Core
{
    class Controller : IController
    {
        private AstronautRepository astronautReopsitory;
        private PlanetRepository planetsRepository;
        private int exploredPlanetsCount;
        public Controller()
        {
            astronautReopsitory = new AstronautRepository();
            planetsRepository = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;
            switch (type)
            {
                case "Biologist":  astronaut = new Biologist(astronautName);break;
                case "Geodesist":astronaut = new Geodesist(astronautName);break;
                case "Meteorologist":astronaut = new Meteorologist(astronautName);break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            astronautReopsitory.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            
            planetsRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded,planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var planet = planetsRepository.FindByName(planetName);
            var astronautsOnMission = astronautReopsitory.Models.Where(x => x.Oxygen > 60).ToArray();
            if (!astronautsOnMission.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            var mission = new Mission();
            mission.Explore(planet, astronautsOnMission);
            var deadAstronauts = astronautsOnMission.Count(x => !x.CanBreath);
            exploredPlanetsCount++;
            return string.Format(OutputMessages.PlanetExplored,planetName,deadAstronauts);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var item in astronautReopsitory.Models)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronautReopsitory.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidRetiredAstronaut);
            }
            astronautReopsitory.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired,astronautName);
        }
    }
}
