using System;
using NLog;

namespace NLogTestprojekt
{
    internal class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        // https://betterstack.com/community/guides/logging/how-to-start-logging-with-nlog/
        static void Main(string[] args)
        {
            logger.Error("This is an error message");
            Console.Read();
        }
    }
}