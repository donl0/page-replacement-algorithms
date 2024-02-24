using Domain.Interfaces.Replacer;

namespace Domain.Interfaces.Adresser
{
    public abstract class BasePageAdresser : IPageAdresser
    {
        private readonly IPageReplacer _replacer;

        private readonly List<int> _adressOrder;
        private readonly int _primaryMemoryCapacity;

        private List<int> _primaryMemory = new List<int>();

        protected int PrimaryMemoryCapacity => _primaryMemoryCapacity;
        protected IReadOnlyCollection<int> AdressOrder => _adressOrder;
        protected IReadOnlyCollection<int> PrimaryMemory => _primaryMemory;

        public BasePageAdresser(IPageReplacer replacer, List<int> adressOrder, List<int> primaryMemory, int mainMemoryCapacity)
        {
            _replacer = replacer;
            _adressOrder = adressOrder;
            _primaryMemoryCapacity = mainMemoryCapacity;
            _primaryMemory = primaryMemory;
        }

        protected bool IsContainPage(int page) {
            return _primaryMemory.Contains(page);
        }

        protected bool IsMemoryLessCapacity() {
            return _primaryMemory.Count < PrimaryMemoryCapacity;
        }

        protected void Add(int page) {
            if (_primaryMemory.Count == _primaryMemoryCapacity)
                throw new IndexOutOfRangeException("out of array");

            _primaryMemory.Add(page);
        }

        protected void NotifyCurrentPage(int page) {
            _replacer.NotifyCurrentPage(page);
        }

        protected void NotifyAdded(int page) { 
            _replacer.NotifyAdded(page);
        }

        protected void Replace(int page) { 
            _replacer.Replace(page);
        }

        public abstract void Adressing();
    }
}
