using SpaceStation.Core.Contracts;
using SpaceStation.IO;
using SpaceStation.IO.Contracts;
using System;
using System.Linq;

namespace SpaceStation.Core
{
    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;
        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            this.controller = new Controller();
            
        }
        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "AddAstronaut")
                    {
                        writer.WriteLine(controller.AddAstronaut(input[1], input[2]));
                    }
                    else if (input[0] == "AddPlanet")
                    {
                        writer.WriteLine(controller.AddPlanet(input[1],input.Skip(2).ToArray()));
                    }
                    else if (input[0] == "RetireAstronaut")
                    {
                        writer.WriteLine(controller.RetireAstronaut(input[1]));
                    }
                    else if (input[0] == "ExplorePlanet")
                    {
                        writer.WriteLine(controller.ExplorePlanet(input[1]));
                    }
                    else if(input[0] == "Report")
                    {
                        writer.WriteLine(controller.Report());
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
