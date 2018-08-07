using BiscuitMachine.Engine.Enums;

namespace BiscuitMachine.Engine
{
    public interface IMachine
    {
        MachineState Start();

        MachineState Stop();

        MachineState Pause();
    }
}