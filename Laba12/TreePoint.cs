namespace Laba12
{
    public class TreePoint<T>
    {
        public T Data { get; set; }
        public TreePoint<T> Left { get; set; }
        public TreePoint<T> Right { get; set; }

        public TreePoint(T data)
        {
            Data = data;
        }
    }
}