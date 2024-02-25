using Application.Interfaces;
using Domain.Interfaces.Replacer;

namespace Application.Replacer
{
    public abstract class ReplacerWithLogger : PageReplacer, ILoggerReplacer
    {
        private readonly ILoggerReplacer _logger;

        public int Swipes => _logger.Swipes;

        protected ReplacerWithLogger(List<int> virtualMemory, List<int> primaryMemory, ILoggerReplacer logger) : base(virtualMemory, primaryMemory)
        {
            _logger = logger;
        }

        public void Log(int oldPage, int newPage)
        {
            _logger.Log(oldPage, newPage);
        }
    }
}
