using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class StackItem<T> {
        public T hodnota;
        public StackItem<T> prev;

        public StackItem (T _hodnota)
        {
            hodnota = _hodnota;
            prev = null;
        }
    }
    public class Stack<T>
    {
        StackItem<T> top = null;

        public void Add(T addItem)
        {
            StackItem<T> item = new StackItem<T>(addItem);
            item.prev = top;
            top = item;
        }

        public void Delete()
        {
            if (top == null) return;
            top = top.prev;         
        }
    }

    public class StackArray<T>
    {
        private T[] array;
        private int top;
        private int maxN;
        public StackArray (int _maxN) 
        { 
            maxN = _maxN;
            array = new T[maxN];
            top = 0;
        }

        public bool isEmpty()
        {
            return top == 0;
        }

        public void Add (T item)
        {
            if (top == maxN) return;
            array[top] = item;
            top++;
        }

        public void Remove()
        {
            if(top <= 0) return;
            top--;
        }
    }
}
