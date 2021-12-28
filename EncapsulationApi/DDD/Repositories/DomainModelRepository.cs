using System;
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
            Console.WriteLine($"The model state is {model.GetState()}");
            var finalStateYesOrNo = (model.IsFinalState) ? "true":"false";
            Console.WriteLine($"The model is in a final state?  {finalStateYesOrNo}");
           
            await Task.CompletedTask;
        }

    }
}