using System;

namespace BiscuitMachine.Engine.Exceptions
{
    public class BiscuitMachineException : Exception
    {
        public BiscuitMachineException(string message)
            : base(message)
        {
        }
    }
}
