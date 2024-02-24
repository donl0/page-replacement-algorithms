using Application.Interfaces;

namespace ConsoleUI.Logger
{
    internal class LoggerReplacer : ILoggerReplacer
    {
        private int _swipes;

        public int Swipes => _swipes;

        public void Log(int oldPage, int newPage)
        {
            _swipes += 1;

            Console.WriteLine("");
            Console.WriteLine($"page:{oldPage} replaced on: {newPage}");
            Console.WriteLine($"swipes count {_swipes}");
        }
    }
}
