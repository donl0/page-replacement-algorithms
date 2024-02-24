namespace Domain.Interfaces.Replacer
{
    public abstract class PageReplacer : IPageReplacer
    {
        private readonly List<int> _requestOrder;
        private List<int> _primaryMemory = new List<int>();

        protected PageReplacer(List<int> virtualMemory, List<int> primaryMemory)
        {
            _requestOrder = virtualMemory;
            _primaryMemory = primaryMemory;
        }

        protected void AddPage(int page) { 
            _primaryMemory.Add(page);
        }
        protected void RemovePage(int page) { 
            _primaryMemory.Remove(page);
        }

        public abstract void NotifyCurrentPage(int page);

        public abstract void Replace(int page);

        public abstract void NotifyAdded(int page);
    }
}
