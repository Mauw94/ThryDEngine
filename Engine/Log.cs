namespace ThryDEngine.Engine
{
    /// <summary>
    /// Logging.
    /// </summary>
    public class Log
    {
        public static void Normal(string msg)
        {
            var message = $"[MSG] - {msg}";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

            WriteToFile(message);
        }

        public static void Info(string msg)
        {
            var message = $"[INFO] - {msg}";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

            WriteToFile(message);
        }

        public static void Warning(string msg)
        {
            var message = $"[WARNING] - {msg}";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

            WriteToFile(message);
        }

        public static void Error(string msg)
        {
            var message = $"[ERROR] - {msg}";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;

            WriteToFile(message);
        }

        private static void WriteToFile(string msg)
        {
            msg += $"\t{DateTime.Now}";

            Directory.CreateDirectory("Logs");

            using StreamWriter file = new("Logs/log.txt", append: true);
            file.WriteLine(msg);
        }
    }
}
