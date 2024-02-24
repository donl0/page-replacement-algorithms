namespace Domain.Interfaces.Replacer
{
    public interface IPageReplacer
    {
        public void Replace(int page);
        public void NotifyCurrentPage(int page);
        public void NotifyAdded(int page);
    }
}
