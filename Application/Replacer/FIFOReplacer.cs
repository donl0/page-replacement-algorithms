using Application.Interfaces;

namespace Application.Replacer
{
    public sealed class FIFOReplacer : ReplacerWithLogger
    {
        private Queue<int> _tempPages = new Queue<int>();

        public FIFOReplacer(List<int> virtualMemory, List<int> primaryMemory, ILoggerReplacer logger) : base(virtualMemory, primaryMemory, logger)
        {
        }

        public override void NotifyAdded(int page)
        {
            _tempPages.Enqueue(page);
        }

        public override void NotifyCurrentPage(int page)
        {
        }

        public override void Replace(int newPage)
        {
            var success = _tempPages.TryDequeue(out int pageToRemove);

            if (success == false)
                throw new ArgumentNullException("Alghorithm hasn't been notified");

            RemovePage(pageToRemove);
            _tempPages.Enqueue(newPage);
            AddPage(newPage);

            Log(pageToRemove, newPage);
        }
    }
}
