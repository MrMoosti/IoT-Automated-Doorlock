using System;

namespace Rfid.Logger
{

    public class LoggerOptions
    {

        /// <summary>
        /// The color that the message will have when printing something to the console.
        /// </summary>
        public ConsoleColor Color { get; set; } = ConsoleColor.Gray;


        /// <summary>
        /// Whether or not the log will get a timestamp.
        /// </summary>
        public bool UseTimeStamp { get; set; } = true;


        /// <summary>
        /// Creates a new <see cref="LoggerOptions"/>.
        /// </summary>
        public LoggerOptions()
        {

        }


        /// <summary>
        /// Creates a new <see cref="LoggerOptions"/>.
        /// </summary>
        /// <param name="color">
        /// The color that the message will have when printing something to the console.
        /// </param>
        public LoggerOptions(ConsoleColor color)
        {
            Color = color;
        }


        /// <summary>
        /// Creates a new <see cref="LoggerOptions"/>.
        /// </summary>
        /// <param name="useTimeStamp">
        /// Whether or not the log will get a timestamp.
        /// </param>
        public LoggerOptions(bool useTimeStamp)
        {
            UseTimeStamp = useTimeStamp;
        }
    }
}
