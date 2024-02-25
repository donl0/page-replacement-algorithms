using Domain.Interfaces.Adresser;

namespace ConsoleUI.Builder
{
    internal interface IAlgorithmBuilder
    {
        public IPageAdresser BuildFifo(List<int> adressOrder, int capacity);
        public IPageAdresser BuildLRU(List<int> adressOrder, int capacity);
        public IPageAdresser BuildOptimal(List<int> adressOrder, int capacity);
    }
}
