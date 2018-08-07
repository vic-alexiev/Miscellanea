using BiscuitMachine.Engine.Enums;
using System;
using System.Threading;

namespace BiscuitMachine.Engine
{
    public class Machine : IMachine
    {
        private IOven _oven;
        private IMotor _motor;

        public Machine(IOven oven, IMotor motor)
        {
            _oven = oven;
            _motor = motor;
        }

        public MachineState Start()
        {
            int temperature = _oven.SwitchOn();
            while (temperature < 220)
            {
                Thread.Sleep(new TimeSpan(0, 1, 0));
                temperature = _oven.GetTemperature();
            }
            _motor.Start();
            return MachineState.Started;
        }

        public MachineState Stop()
        {
            return MachineState.Stopped;
        }

        public MachineState Pause()
        {
            return MachineState.Paused;
        }
    }
}
