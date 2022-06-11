using System;

namespace TMS.NET15.RobotVacuumCleaner
{
    public interface IControlBus
    {
        event Action<CommandArguments> CommandExecuted;

        void SendCommand(string command);
    }

    public class ControlBus : IControlBus
    {
        public event Action<CommandArguments> CommandExecuted;

        public void SendCommand(string command)
        {
            CommandExecuted?.Invoke(new CommandArguments(command));
        }
    }

    public class CommandArguments
    {
        public CommandArguments(string command)
        {
            Command = command;
        }

        public string Command { get; }
    }
}
