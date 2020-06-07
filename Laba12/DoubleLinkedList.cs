using System.Collections;
using System.Collections.Generic;

namespace Laba12
{
    public class DoublyLinkedList<T> : IEnumerable<T>  
    {
        public DoublePoint<T> firstPoint; 
        public DoublePoint<T> lastPoint; 
        public int count;  // количество элементов в списке
 
        // добавление элемента
        public void Add(T data)
        {
            DoublePoint<T> point = new DoublePoint<T>(data);
 
            if (firstPoint == null)
                firstPoint = point;
            else
            {
                lastPoint.Next = point;
                point.Previous = lastPoint;
            }
            lastPoint = point;
            count++;
        }
        
        // удаление
        public bool Remove(T data)
        {
            DoublePoint<T> current = firstPoint;
 
            // поиск удаляемого узла
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }
            if(current!=null)
            {
                // если узел не последний
                if(current.Next!=null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    // если последний, переустанавливаем tail
                    lastPoint = current.Previous;
                }
 
                // если узел не первый
                if(current.Previous!=null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    // если первый, переустанавливаем head
                    firstPoint = current.Next;
                }
                count--;
                return true;
            }
            return false;
        }
 
        public int Count { get { return count; } }

        public void Clear()
        {
            firstPoint = null;
            lastPoint = null;
            count = 0;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublePoint<T> current = firstPoint;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
 
        public IEnumerable<T> BackEnumerator()
        {
            DoublePoint<T> current = lastPoint;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}