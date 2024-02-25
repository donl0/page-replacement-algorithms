using Application.Extensions;
using Application.Interfaces;

namespace Application.Replacer
{
    public sealed class LRUReplacer : ReplacerWithLogger
    {
        private Queue<int> _lastUsedPages = new Queue<int>();

        public LRUReplacer(List<int> virtualMemory, List<int> primaryMemory, ILoggerReplacer logger) : base(virtualMemory, primaryMemory, logger)
        {
        }

        public override void NotifyAdded(int page)
        {
            _lastUsedPages.Enqueue(page);
        }

        public override void NotifyCurrentPage(int page) {
            TryCorrectLastUsed(page, _lastUsedPages);
        }

        public override void Replace(int newPage)
        {
            var success = _lastUsedPages.TryDequeue(out int pageToRemove);

            if (success == false)
                throw new ArgumentNullException("Alghorithm hasn't been notified");

            RemovePage(pageToRemove);
            AddPage(newPage);
            _lastUsedPages.Enqueue(newPage);

            Log(pageToRemove, newPage);
        }

        private bool TryCorrectLastUsed(int page, Queue<int> lastUsed) {
            if (lastUsed.Contains(page) == true)
            {
                _lastUsedPages = _lastUsedPages.Delete<int>(page);

                _lastUsedPages.Enqueue(page);

                return true;
            }

            return false;
        }
    }
}
