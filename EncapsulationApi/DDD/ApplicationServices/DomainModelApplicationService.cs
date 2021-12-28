using System.Threading.Tasks;
using EncapsulationApi.DDD.DomainModels;
using EncapsulationApi.DDD.Repositories;

namespace EncapsulationApi.DDD.ApplicationServices
{
    public class DomainModelApplicationService : IDomainModelApplicationService

    {
        private readonly IDomainModelRepository _domainModelRepository;
        public DomainModelApplicationService(
            IDomainModelRepository domainModelRepository)
        {
            _domainModelRepository = domainModelRepository;
        }

        /// <summary>
        /// A simple method on our Application Service which knows nothing about
        /// how the work is done, but simply what to call when to get the work completed.
        /// </summary>
        public async Task SubmitDraft()
        {
            var domainModel = await _domainModelRepository.GetDomainModel();
            domainModel.ChangeState(DomainModelState.Submitted);
            await _domainModelRepository.SaveDomainModel(domainModel);
        }
    }
}