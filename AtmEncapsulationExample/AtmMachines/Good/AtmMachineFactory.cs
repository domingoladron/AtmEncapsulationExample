namespace AtmEncapsulationExample.AtmMachines.Good
{
    /// <summary>
    /// A simple factory to get back our Atm Machine
    /// </summary>
    public static class AtmMachineFactory
    {
        public static IAtmMachine GetAtmMachine()
        {
            return new AtmMachine();
        }
    }
}