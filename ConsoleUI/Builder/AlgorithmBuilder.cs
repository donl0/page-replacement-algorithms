using Application.Adresser;
using Application.Interfaces;
using Application.Replacer;
using ConsoleUI.Logger;
using Domain.Interfaces.Adresser;
using Domain.Interfaces.Replacer;

namespace ConsoleUI.Builder
{
    internal sealed class AlgorithmBuilder : IAlgorithmBuilder
    {
        public IPageAdresser BuildFifo(List<int> adressOrder, int capacity)
        {
            MakeCommon(out ILoggerAdresser adresserLoger, out ILoggerReplacer replacerLoger, out List<int> primaryMemory);

            IPageReplacer fifo = new FIFOReplacer(adressOrder, primaryMemory, replacerLoger);
            IPageAdresser adresser = new PageAdresser(fifo, adressOrder, primaryMemory, capacity, adresserLoger);

            return adresser;
        }

        public IPageAdresser BuildLRU(List<int> adressOrder, int capacity)
        {
            MakeCommon(out ILoggerAdresser adresserLoger, out ILoggerReplacer replacerLoger, out List<int> primaryMemory);

            IPageReplacer rlu = new LRUReplacer(adressOrder, primaryMemory, replacerLoger);
            IPageAdresser adresser = new PageAdresser(rlu, adressOrder, primaryMemory, capacity, adresserLoger);

            return adresser;
        }

        public IPageAdresser BuildOptimal(List<int> adressOrder, int capacity)
        {
            MakeCommon(out ILoggerAdresser adresserLoger, out ILoggerReplacer replacerLoger, out List<int> primaryMemory);

            IPageReplacer optimal = new OptimalReplacer(adressOrder, primaryMemory, replacerLoger);
            IPageAdresser adresser = new PageAdresser(optimal, adressOrder, primaryMemory, capacity, adresserLoger);

            return adresser;
        }

        private void MakeCommon(out ILoggerAdresser adresserLoger, out ILoggerReplacer replacerLoger, out List<int> primaryMemory) {
            primaryMemory = new List<int>();

            adresserLoger = new LoggerAdresser();
            replacerLoger = new LoggerReplacer();
        }
    }
}
