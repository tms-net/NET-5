using System;
using System.Windows.Input;

namespace TMS.NET15.RobotVacuumCleaner.Wpf
{
    public class ControlBusCommand : ICommand
    {
        private readonly IControlBus _controlBus;

        public ControlBusCommand(IControlBus controlBus)
        {
            _controlBus = controlBus;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _controlBus?.SendCommand(parameter as string);
        }
    }
}
