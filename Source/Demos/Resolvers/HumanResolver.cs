namespace Demos.Resolvers
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Demos.DataLoaders;
    using Demos.Models;
    using Demos.Repositories;
    using HotChocolate;

    public class HumanResolver
    {
        private readonly IHumanRepository humanRepository;

        public HumanResolver(IHumanRepository humanRepository) => this.humanRepository = humanRepository;

        public Task<Human> GetHumanAsync(IHumanDataLoader humanDataLoader, Guid id, CancellationToken cancellationToken) =>
            humanDataLoader.LoadAsync(id, cancellationToken);

        public Task<List<Character>> GetFriendsAsync([Parent] Human human, CancellationToken cancellationToken) =>
            this.humanRepository.GetFriendsAsync(human, cancellationToken);
    }
}
