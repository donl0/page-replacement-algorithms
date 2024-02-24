using Application.Adresser;
using Application.Interfaces;
using Application.Replacer;
using ConsoleUI.Logger;
using Domain.Interfaces.Adresser;
using Domain.Interfaces.Replacer;

public static class Program
{
    public static void Main(string[] args)
    {
        List<int> adressOrder = new List<int>() {
        11, 10, 5, 11, 19, 6, 2, 4, 12, 6, 17, 8, 10, 9, 18, 2, 3, 2, 4, 8, 15, 4, 8, 15, 14,
        5, 13, 7, 9, 15, 19, 20, 17, 11, 3, 15, 18, 20, 5, 2, 5, 4, 13, 15, 7, 14
        };

        int capacity = 6;
        List<int> primaryMemory = new List<int>();

        ILoggerAdresser adresserLoger = new LoggerAdresser();
        ILoggerReplacer replacerLoger = new LoggerReplacer();

        IPageReplacer fifo = new FIFOReplacer(adressOrder, primaryMemory, replacerLoger);
        IPageAdresser pageAdresser = new PageAdresser(fifo, adressOrder, primaryMemory, capacity, adresserLoger);

        pageAdresser.Adressing();
    }
}