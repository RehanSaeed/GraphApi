namespace Demos.Mappers
{
    using System;
    using Boxed.Mapping;
    using Demos.Models;
    using Demos.Services;

    public class HumanInputToHumanMapper : IImmutableMapper<HumanInput, Human>
    {
        private readonly IClockService clockService;

        public HumanInputToHumanMapper(IClockService clockService) => this.clockService = clockService;

        public Human Map(HumanInput source)
        {
            var now = this.clockService.UtcNow;

            var human = new Human(
                Id: Guid.NewGuid(),
                Name: source.Name,
                HomePlanet: source.HomePlanet,
                DateOfBirth: source.DateOfBirth,
                Created: now,
                Modified: now);

            if (source.AppearsIn is not null)
            {
                human.AppearsIn.AddRange(source.AppearsIn);
            }

            return human;
        }
    }
}
