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

    public class DroidResolver
    {
        private readonly IDroidRepository droidRepository;

        public DroidResolver(IDroidRepository droidRepository) => this.droidRepository = droidRepository;

        public Task<Droid> GetDroidAsync(IDroidDataLoader droidDataLoader, Guid id, CancellationToken cancellationToken) =>
            droidDataLoader.LoadAsync(id, cancellationToken);

        public Task<List<Character>> GetFriendsAsync([Parent] Droid droid, CancellationToken cancellationToken) =>
            this.droidRepository.GetFriendsAsync(droid, cancellationToken);
    }
}
