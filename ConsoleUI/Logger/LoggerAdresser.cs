using Application.Interfaces;

namespace ConsoleUI.Logger
{
    internal class LoggerAdresser : ILoggerAdresser
    {
        public void Log(IEnumerable<int> primaryMemory)
        {
            foreach (var item in primaryMemory)
            {
                Console.Write(item.ToString() + " |");
            }
            Console.WriteLine();
        }
    }
}
