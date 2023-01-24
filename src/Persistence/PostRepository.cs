using Cyrus.Mongodb.Contracts;
using Cyrus.Mongodb.Repository;
using Domain;
using MongoDB.Driver;

namespace Persistence;

public class PostRepository : 
			MongoRepository<Post>,
			IMongoRepository<Post>
{
	public PostRepository(IMongoDatabase mongoDatabase, string collection) : base(mongoDatabase, collection)
	{
	}
}