using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace mongo_aspnet_api
{
    public class DateCounterAsyncMongoRepository : IMongoAsyncRepository<DateCounter>
    {
        private readonly IMongoCollection<DateCounter> _fundingDates;

        public DateCounterAsyncMongoRepository(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.Database);

            _fundingDates = database.GetCollection<DateCounter>("dateCounter");
        }

        public async Task<IEnumerable<DateCounter>> GetAll()
        {
            return await _fundingDates.Find(_ => true).ToListAsync();
        }

        public async Task<DateCounter> GetById(ObjectId id)
        {
            return await _fundingDates.Find(x=> x._id == id).SingleAsync();
        }

        public void Add(DateCounter fundingDate)
        {
            _fundingDates.InsertOne(fundingDate);
        }

        public void AddMany(IEnumerable<DateCounter> fundingDates)
        {
            _fundingDates.InsertMany(fundingDates);
        }

        public async void Update(DateCounter fundingDate)
        {

            await _fundingDates.ReplaceOneAsync(x => x._id == fundingDate._id,fundingDate);
        }


        public async void Remove(ObjectId id)
        {
            await _fundingDates.DeleteManyAsync(x => x._id == id);
        }

        public IMongoQueryable<DateCounter> Queryable()
        {
            return _fundingDates.AsQueryable();
        }


    }
    
}