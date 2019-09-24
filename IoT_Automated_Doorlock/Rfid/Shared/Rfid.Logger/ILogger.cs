
namespace Rfid.Logger
{

    public interface ILogger
    {

        /// <summary>
        /// Logs a message to the console and logs the message to the Console logs folder.
        /// </summary>
        /// <param name="message">The message that the user typed.</param>
        /// <param name="loggerOptions">The <see cref="LoggerOptions"/> that will be used to set the setting for the log message.</param>
        void Log(string message, LoggerOptions loggerOptions = null);


        /// <summary>
        /// Logs a message to text file.
        /// </summary>
        /// <param name="folder">The folder where you want to store the message.</param>
        /// <param name="text">The text you want to save.</param>
        void LogToFile(string folder, string text);
    }
}
