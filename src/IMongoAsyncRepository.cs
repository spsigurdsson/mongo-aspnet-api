using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace mongo_aspnet_api
{
    public interface IMongoAsyncRepository<TK> : IAsyncRepository<ObjectId, IMongoQueryable<TK>,TK>
    {
        
    }
}