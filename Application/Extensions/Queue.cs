namespace Application.Extensions
{
    public static class Queue
    {
        public static Queue<T> Delete<T>(this Queue<T> queue, T item) {

            Queue<T> tempQueue = new Queue<T>();

            while (queue.Count > 0)
            {
                T current = queue.Dequeue();

                if (current.Equals(item) == false)
                {
                    tempQueue.Enqueue(current);
                }
            }

            return tempQueue;
        }
    }
}
