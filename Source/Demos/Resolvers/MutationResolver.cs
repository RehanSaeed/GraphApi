namespace Demos.Resolvers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Boxed.Mapping;
    using Demos.Models;
    using Demos.Repositories;
    using HotChocolate.Subscriptions;

    public class MutationResolver
    {
        private readonly IImmutableMapper<HumanInput, Human> humanInputToHumanMapper;
        private readonly IHumanRepository humanRepository;
        private readonly ITopicEventSender topicEventSender;

        public MutationResolver(
            IImmutableMapper<HumanInput, Human> humanInputToHumanMapper,
            IHumanRepository humanRepository,
            ITopicEventSender topicEventSender)
        {
            this.humanInputToHumanMapper = humanInputToHumanMapper;
            this.humanRepository = humanRepository;
            this.topicEventSender = topicEventSender;
        }

        public async Task<Human> CreateHumanAsync(HumanInput humanInput, CancellationToken cancellationToken)
        {
            var human = this.humanInputToHumanMapper.Map(humanInput);
            human = await this.humanRepository
                .AddHumanAsync(human, cancellationToken)
                .ConfigureAwait(false);
            await this.topicEventSender
                .SendAsync(nameof(SubscriptionResolver.OnHumanCreatedAsync), human.Id, CancellationToken.None)
                .ConfigureAwait(false);
            return human;
        }
    }
}
