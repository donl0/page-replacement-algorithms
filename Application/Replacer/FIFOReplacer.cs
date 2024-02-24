using Application.Interfaces;
using Domain.Interfaces.Replacer;

namespace Application.Replacer
{
    public class FIFOReplacer : PageReplacer
    {
        private readonly ILoggerReplacer _logger;

        private Queue<int> _tempPages = new Queue<int>();

        public FIFOReplacer(List<int> adressOrder, List<int> primaryMemory, ILoggerReplacer logger) : base(adressOrder, primaryMemory)
        {
            _logger = logger;
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

            _logger.Log(pageToRemove, newPage);
        }
    }
}
