using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Laba12
{
   public class Queue<T> : IEnumerable<T>
    {
        public Point<T> firstPoint; // головной/первый элемент
        public Point<T> lastPoint; // последний/хвостовой элемент
        int count;

        public Queue()
        {
            firstPoint = null;
            lastPoint = null;
            count = 0;
        }

        public Queue(int capacity)
        {
            firstPoint = null;
            lastPoint = null;
            count = capacity;
        }

        public Queue(Queue<T> collection)
        {
            Point<T> temp = collection.firstPoint;
            count = collection.count;
            while (temp != null)
            {
                Enqueue(temp.Data);
                temp = temp.Next;
            }
        }
        
        // добавление в очередь
        public void Enqueue(T data)
        {
            Point<T> node = new Point<T>(data);
            Point<T> tempNode = lastPoint;
            lastPoint = node;
            if (count == 0)
                firstPoint = lastPoint;
            else
                tempNode.Next = lastPoint;
            count++;
        }

        public void Enqueue(params T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Enqueue(data[i]);
            }
        }

        // удаление из очереди
        public T Dequeue()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = firstPoint.Data;
            firstPoint = firstPoint.Next;
            count--;
            return output;
        }

        public void Dequeue(int count)
        {
            if (count > Count)
            {
                throw new InvalidCastException();
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Dequeue();
                }
            }
        }
        
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
 
        public void Clear()
        {
            firstPoint = null;
            lastPoint = null;
            count = 0;
        }

        public bool Contains(T data, out T result)
        {
            result = firstPoint.Data;
            Point<T> current = firstPoint;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    result = current.Data;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Point<T> current = firstPoint;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}