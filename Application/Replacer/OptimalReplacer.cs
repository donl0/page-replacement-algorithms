using Application.Extensions;
using Application.Interfaces;
using Domain.Interfaces.Replacer;

namespace Application.Replacer
{
    public class OptimalReplacer : PageReplacer
    {
        private readonly ILoggerReplacer _logger;

        private int _index = -1;

        public OptimalReplacer(List<int> virtualMemory, List<int> primaryMemory, ILoggerReplacer logger) : base(virtualMemory, primaryMemory)
        {
            _logger = logger;
        }

        public override void NotifyAdded(int page)
        {
        }

        public override void NotifyCurrentPage(int page)
        {
            _index++;
        }

        public override void Replace(int newPage)
        {
             PrimaryMemory.FarestElementAfterIndex<int>(_index, RequestOrder, out int pageToRemove);

            RemovePage(pageToRemove);
            AddPage(newPage);

            _logger.Log(pageToRemove, newPage);
        }

    }
}
