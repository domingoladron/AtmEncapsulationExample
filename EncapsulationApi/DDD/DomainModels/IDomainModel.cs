namespace EncapsulationApi.DDD.DomainModels
{
    /// <summary>
    /// The interface to our domain model
    /// </summary>
    public interface IDomainModel
    {
        public void ChangeState(DomainModelState state);
    }
}