namespace Laba12
{
    public class Point<T>
    {
           public Point(T data)
           {
               Data = data;
           }
           
           public T Data { get; set; }
           public Point<T> Next { get; set; }
       }
    }