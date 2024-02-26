using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class QueueItem<T>
    {
        private T item;
        private QueueItem<T> next;

        public QueueItem(T _item)
        {
            item = _item;
            next = null;
        }

        public T Item => item;
        public QueueItem<T> Next => next;
        public void SetNext(QueueItem<T> item)
        {
            next = item;
        }
    }

    public class Queue<T>
    {
        private QueueItem<T> start;
        private QueueItem<T> end;

        Queue()
        {
            start = null;
            end = null;
        }

        public void Add(T item)
        {
            QueueItem<T> newItem = new QueueItem<T>(item);
            if (start == null)
            {
                start = newItem;
                end = newItem;
            } else
            {
                end.SetNext(newItem);
                end = newItem;
            }
        }

        public void Remove()
        {
            if (start == null) return;
            start = start.Next;
        }

        public bool IsEmpty()
        {
            return start == null;
        }
    }

    public class QueueArray<T>
    {
        private int start = 0, end, count, maxSize;
        private T[] array;

        public QueueArray(int size) 
        {
            array = new T[size];
            maxSize = size;
            start = 0;
            end = size - 1; 
            count = 0;
        }

        public void Add(T item)
        {
            if (count == maxSize) return;
            if(end == maxSize - 1) {
                end = 0;
                return;
            } 
            
            end++;
            count++;
            array[end] = item;    
        }

        public void Remove()
        {
            if (IsEmpty()) return;
            if (start == maxSize - 1) start = 0;
            else start++;
            count--;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public T GetValue(int index)
        {
            return array[index];
        }
    }
}
