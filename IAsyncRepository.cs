using System.Collections.Generic;
using System.Threading.Tasks;

namespace mongo_aspnet_api
{
    public interface IAsyncRepository<in T1, out T2,T3>
    {
        Task<IEnumerable<T3>> GetAll();

        Task<T3> GetById(T1 id);

        void Add(T3 fundingDate);

        void AddMany(IEnumerable<T3> fundingDates);

        void Update(T3 fundingDate);

        void Remove(T1 id);

        T2 Queryable();
    }
}