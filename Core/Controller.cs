using System.Linq;
using System.Text;
using System;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Mission;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private IMission mission;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;
            switch(type)
            {
                case "Biologist": astronaut = new Biologist(astronautName);break;
                case "Geodesist": astronaut = new Geodesist(astronautName);break;
                case "Meteorologist":astronaut = new Meteorologist(astronautName);break;
                default:
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronautRepository.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded,type,astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planetRepository.Add(planet);
            return string.Format(OutputMessages.PlanetAdded,planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var astronautsOnMission = astronautRepository.Models.Where(x=>x.Oxygen>60).ToList();
            if(!astronautsOnMission.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IPlanet planet = planetRepository.FindByName(planetName);
            this.mission.Explore(planet,astronautsOnMission);
            int deadAstronauts = astronautsOnMission.Count(x=>!x.CanBreath);
            this.exploredPlanetsCount++;

            return string.Format(OutputMessages.PlanetExplored,planetName,deadAstronauts);
        }

        public string Report()
        {
            var report = new StringBuilder();
            report.AppendLine($"{exploredPlanetsCount} planets were explored!");
            report.AppendLine("Astronauts info:");
            foreach (var astronaut in this.astronautRepository.Models)
            {
                report.AppendLine(astronaut.ToString());
            }
            return report.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautRepository.FindByName(astronautName);
            if(astronaut==null)
            {
                throw  new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut,astronautName));
            }
            
            this.astronautRepository.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired,astronautName);
        }
    }
}
