using Application.Interfaces;
using Domain.Interfaces.Adresser;
using Domain.Interfaces.Replacer;

namespace Application.Adresser
{
    public sealed class PageAdresser : BasePageAdresser
    {
        private readonly ILoggerAdresser _loggerAdresser;

        public PageAdresser(IPageReplacer replacer, List<int> adressOrder, List<int> primaryMemory, int mainMemoryCapacity, ILoggerAdresser loggerAdresser) : base(replacer, adressOrder, primaryMemory, mainMemoryCapacity)
        {
            _loggerAdresser = loggerAdresser;
        }

        public override void Adressing()
        {
            foreach (var page in AdressOrder)
            {
                _loggerAdresser.Log(PrimaryMemory);

                NotifyCurrentPage(page);

                if (IsContainPage(page) == true)
                    continue;

                if (IsMemoryLessCapacity())
                {
                    Add(page);
                    NotifyAdded(page);
                }
                else
                {
                    Replace(page);
                }
            }
        }
    }
}
