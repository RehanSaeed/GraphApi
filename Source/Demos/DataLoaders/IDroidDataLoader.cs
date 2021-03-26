namespace Demos.DataLoaders
{
    using System;
    using Demos.Models;
    using GreenDonut;

    public interface IDroidDataLoader : IDataLoader<Guid, Droid>
    {
    }
}
