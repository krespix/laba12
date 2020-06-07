namespace Laba12
{
    public class DoublePoint<T>
    {
        public DoublePoint(T data)
        {
            Data = data;
        }
        
        public T Data { get; set; }
        public DoublePoint<T> Next { get; set; }
        public DoublePoint<T> Previous { get; set; }
    }
}