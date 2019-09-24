using System;
using System.IO;

namespace Rfid.Logger
{

    public class Logger : ILogger
    {
        private readonly object _lock = new object();


        /// <inheritdoc />
        public void Log(string message, LoggerOptions loggerOptions = null)
        {
            if (loggerOptions == null) loggerOptions = new LoggerOptions();

            var timeStamp = loggerOptions.UseTimeStamp ? $"{DateTime.UtcNow:hh:mm:ss.fff} : " : "";

            Console.ForegroundColor = loggerOptions.Color;
            Console.WriteLine(timeStamp + message);
            Console.ResetColor();

            LogToFile("Console", message);
        }


        /// <inheritdoc />
        public void LogToFile(string folder, string text)
        {
            var filePath = $"logs/{folder}/{DateTime.UtcNow:MMMM, yyyy}".ToLower();
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
            filePath += $"/{DateTime.UtcNow:dddd, MMMM d, yyyy}.txt".ToLower();
            lock (_lock)
            {
                using (var file = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None))
                {
                    using (var sw = new StreamWriter(file))
                    {
                        sw.WriteLine($"{DateTime.UtcNow:T} : {text}");
                    }
                }
            }
        }
    }
}

