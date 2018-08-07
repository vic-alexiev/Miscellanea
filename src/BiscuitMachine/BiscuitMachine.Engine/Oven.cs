using BiscuitMachine.Engine.Enums;
using BiscuitMachine.Engine.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BiscuitMachine.Engine
{
    public class Oven : IOven
    {
        private Stopwatch _onStopwatch = new Stopwatch();
        private Stopwatch _offStopwatch = new Stopwatch();
        private OvenState _state = OvenState.Off;
        private int _roomTemperature = 20;
        private int _temperatureIncreasePerMinute = 18;
        private int _temperatureDecreasePerMinute = 9;

        public Oven()
        {
        }

        public int SwitchOn()
        {
            if (_state == OvenState.Off)
            {
                _onStopwatch.Start();
                _state = OvenState.On;
                return GetTemperature();
            }
            else
            {
                throw new BiscuitMachineException("Oven has already been switched on.");
            }
        }

        public int SwitchOff()
        {
            if (_state == OvenState.On)
            {
                _onStopwatch.Stop();
                _offStopwatch.Start();
                _state = OvenState.Off;
                return GetTemperature();
            }
            else
            {
                throw new BiscuitMachineException("Oven must be switched on first.");
            }
        }

        public void ShutDown()
        {
            _offStopwatch.Stop();
        }

        public int GetTemperature()
        {
            if (_state == OvenState.On)
            {
                int elapsedMinutes = (int)_onStopwatch.Elapsed.TotalMinutes;
                return elapsedMinutes * _temperatureIncreasePerMinute;
            }
            else
            {
                int elapsedMinutes = (int)_offStopwatch.Elapsed.TotalMinutes;
                return elapsedMinutes * _temperatureDecreasePerMinute;
            }
        }
    }
}
