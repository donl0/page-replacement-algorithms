namespace Application.Extensions
{
    public static class List
    {
        public static List<T> FarestElementAfterIndex<T>(this List<T> list, int index, List<T> listFindIn, out T item)
        {
            var indexes = list.Select(element =>
            {
                int indexOfElement = listFindIn.IndexOf(element, index + 1);
                return indexOfElement >= 0 ? indexOfElement : int.MaxValue;
            })
           .ToList();

            int maxIndex = indexes.IndexOf(indexes.Max());
            item = list[maxIndex];

            return list;
        }
    }
}
