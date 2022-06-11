using System;
using System.Diagnostics;
using System.Threading;

namespace TMS.NET15.RobotVacuumCleaner
{
    public class VacuumCleaner
    {
        private const int SleepingIntervalMs = 1500;
        private const int CleaningIntervalMs = 300;
        private const int ChargingIntervalMs = 900;

        private readonly IControlBus _controlBus;

        bool _isStarted = false;
        bool _isCleaning = false;
        bool _isCharging = false;

        public VacuumCleaner(IControlBus controllers)
        {
            _controlBus = controllers;
        }

        public void Start()
        {
            _controlBus.CommandExecuted += OnCommandExecuted;
            _isStarted = true;
        }

        public void Run()
        {
            while (_isStarted)
            {
                while (_isCleaning)
                {
                    Thread.Sleep(CleaningIntervalMs);
                    Trace.WriteLine("Cleaning.......");
                }

                while (_isCharging)
                {
                    Thread.Sleep(ChargingIntervalMs);
                    Trace.WriteLine("Charging.......");
                }

                Thread.Sleep(SleepingIntervalMs);
                Trace.WriteLine("Sleeping.......");
            }
        }

        public void Stop()
        {
            _isStarted = false;
        }

        private void OnCommandExecuted(CommandArguments obj)
        {
            switch (obj.Command)
            {
                case "StartCleaning":
                    StartCleaning();
                    break;
                case "FinishCleaning":
                    FinishCleaning();
                    break;
                case "ReturnToChargingDock":
                    ReturnToChargingDock();
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        private void ReturnToChargingDock()
        {
            _isCleaning = false;
            _isCharging = true;
        }

        private void FinishCleaning()
        {
            _isCleaning = false;
        }

        private void StartCleaning()
        {
            _isCharging = false;
            _isCleaning = true;
        }
    }
}