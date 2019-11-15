namespace SpaceStation.Models.Planets
{
    using System.Collections.Generic;
    using Repositories.Contracts;

    public interface IPlanet
    {
        ICollection<string> Items { get; }

        string Name { get; }
    }
}