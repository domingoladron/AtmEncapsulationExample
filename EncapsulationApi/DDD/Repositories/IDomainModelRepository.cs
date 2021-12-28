using System.Threading.Tasks;
using EncapsulationApi.DDD.DomainModels;

namespace EncapsulationApi.DDD.Repositories
{
    /// <summary>
    /// An interface for our repository
    /// </summary>
    public interface IDomainModelRepository
    {
        Task<IDomainModel> GetDomainModel();

        Task SaveDomainModel(IDomainModel model);

    }
}