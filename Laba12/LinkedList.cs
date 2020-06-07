using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba12
{
    public class LinkedList<T> : IEnumerable<T>  // односвязный список
    {
        public Point<T> firstPoint; // первый элемент
        public Point<T> latPoint; // последний элемент
        public int count;  // количество элементов в списке
 
        // добавление элемента
        public void Add(T data)
        {
            Point<T> point = new Point<T>(data);
 
            if (firstPoint == null)
                firstPoint = point;
            else
                latPoint.Next = point;
            latPoint = point;
 
            count++;
        }
        
        // удаление элемента
        public bool Remove(T data)
        {
            Point<T> current = firstPoint;
            Point<T> previous = null;
 
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;
 
                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            latPoint = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        firstPoint = firstPoint.Next;
 
                        // если после удаления список пуст, сбрасываем tail
                        if (firstPoint == null)
                            latPoint = null;
                    }
                    count--;
                    return true;
                }
 
                previous = current;
                current = current.Next;
            }
            return false;
        }
 
        public int Count { get { return count; } }
        
        // очистка списка
        public void Clear()
        {
            firstPoint = null;
            latPoint = null;
            count = 0;
        }
        
        // реализация интерфейса IEnumerable
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