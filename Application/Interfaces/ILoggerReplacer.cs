namespace Application.Interfaces
{
    public interface ILoggerReplacer
    {
        public int Swipes { get; }

        public void Log(int oldPage, int newPage);
    }
}
