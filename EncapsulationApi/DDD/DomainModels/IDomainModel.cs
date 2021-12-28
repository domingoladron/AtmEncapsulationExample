namespace EncapsulationApi.DDD.DomainModels
{
    /// <summary>
    /// The interface to our domain model
    /// </summary>
    public interface IDomainModel
    {
        public bool IsFinalState { get; }
        public void ChangeState(DomainModelState state);
        public DomainModelState GetState();

    }
}