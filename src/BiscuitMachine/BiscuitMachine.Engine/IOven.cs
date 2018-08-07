namespace BiscuitMachine.Engine
{
    public interface IOven
    {
        int SwitchOn();

        int SwitchOff();

        void ShutDown();

        int GetTemperature();
    }
}