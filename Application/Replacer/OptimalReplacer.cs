using Application.Extensions;
using Application.Interfaces;

namespace Application.Replacer
{
    public sealed class OptimalReplacer : ReplacerWithLogger
    {
        private int _index = -1;

        public OptimalReplacer(List<int> virtualMemory, List<int> primaryMemory, ILoggerReplacer logger) : base(virtualMemory, primaryMemory, logger)
        {
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

            Log(pageToRemove, newPage);
        }

    }
}
