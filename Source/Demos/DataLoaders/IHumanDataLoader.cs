namespace Demos.DataLoaders
{
    using System;
    using Demos.Models;
    using GreenDonut;

    public interface IHumanDataLoader : IDataLoader<Guid, Human>
    {
    }
}
