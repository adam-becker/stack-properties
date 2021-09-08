namespace AwesomeStack
{
    public static class Stack
    {
        private const int DEFAULT_CAPACITY = 10;

        public static Stack<T> Empty<T>(int capacity = DEFAULT_CAPACITY)
        {
            return new Stack<T>(capacity);
        }

        public static Stack<T> Full<T>(int capacity = DEFAULT_CAPACITY)
        {
            return new Stack<T>(capacity, capacity);
        }
    }
}
