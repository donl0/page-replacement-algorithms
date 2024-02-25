namespace Domain.Interfaces.Replacer
{
    public abstract class PageReplacer : IPageReplacer
    {
        private readonly List<int> _requestOrder;
        private List<int> _primaryMemory = new List<int>();

        public List<int> PrimaryMemory => new List<int>(_primaryMemory);
        public List<int> RequestOrder => new List<int>(_requestOrder);

        protected PageReplacer(List<int> requestOrder, List<int> primaryMemory)
        {
            _requestOrder = requestOrder;
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
