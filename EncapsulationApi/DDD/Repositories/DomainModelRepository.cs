using System.Threading.Tasks;
using EncapsulationApi.DDD.DomainModels;

namespace EncapsulationApi.DDD.Repositories
{
    /// <summary>
    /// the implementation of this repository interface
    /// </summary>
    class DomainModelRepository : IDomainModelRepository
    {
        public async Task<IDomainModel> GetDomainModel()
        {
            var retVal = new DomainModel();
            return await Task.FromResult(retVal);
        }

        public async Task SaveDomainModel(IDomainModel model)
        {
            // Do something with the Domain Model, save it, send it somewhere, etc.
            await Task.CompletedTask;
        }

    }
}