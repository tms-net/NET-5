namespace TMS.NET15.FileServer
{

    public class FileLoggerProvider : ILoggerProvider
    {
        
        public ILogger CreateLogger(string categoryName) => new FileLogger();


        public void Dispose()
        {

        }

    }

    internal class FileLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception exception, 
            Func<TState, Exception, string> formatter)
        {
            var logText = formatter(state, exception);

            LogWriter.WriteLogInFile(logText);
        }
    }

    static class LogWriter
    {
        public static async void WriteLogInFile(string logText)
        {
            using StreamWriter writer = new StreamWriter(".\\log.txt", true);
            await writer.WriteLineAsync(logText );
        }
    }
}