using Cyrus.Mongodb.Contracts;
using Domain;
using Mapster;
using MassTransit;
using Messages.History.Contracts;

namespace Application.Consumers;

public class HistoryMessageConsumer : IConsumer<HistoryMessage>
{
	private readonly IMongoRepository<Post> _repository;

	public HistoryMessageConsumer(IMongoRepository<Post> repository)
	{
		_repository = repository;
	}

	public async Task Consume(ConsumeContext<HistoryMessage> context)
	{
		var mapped = context.Message.Adapt<Post>();
		await _repository.AddAsync(mapped);
    }
}

public class HistoryMessageConsumerDefinition
: ConsumerDefinition<HistoryMessageConsumer>
{
	public HistoryMessageConsumerDefinition()
	{
		EndpointName  = "HistoryMicroservice";
		ConcurrentMessageLimit = 10;
	}
}

