using System.Threading.Tasks;

namespace EncapsulationApi.DDD.ApplicationServices
{
    /// <summary>
    /// A simple interface for our domain model application service
    /// </summary>
    public interface IDomainModelApplicationService
    {
        Task SubmitDraft();
    }
}