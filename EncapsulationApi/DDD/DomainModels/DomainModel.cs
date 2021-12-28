namespace EncapsulationApi.DDD.DomainModels
{
    /// <summary>
    /// Our implemented domain model, which of course is isolated from our application service
    /// by its interface
    /// </summary>
    public class DomainModel : IDomainModel
    {
        private DomainModelState _currentState;
        public bool IsFinalState { get; private set; }

        public void ChangeState(DomainModelState state)
        {
            _currentState = state;
            switch (_currentState)
            {
                case DomainModelState.Approved:
                case DomainModelState.Rejected:
                    IsFinalState = true;
                    break;
                case DomainModelState.Draft:
                case DomainModelState.Submitted:
                    IsFinalState = false;
                    break;
                default:
                    break;
            }
        }

        public DomainModelState GetState()
        {
            return _currentState;
        }

        public DomainModel()
        {
            _currentState = DomainModelState.Draft;
        }
    }
}