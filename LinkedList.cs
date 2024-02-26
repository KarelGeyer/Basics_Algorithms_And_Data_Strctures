using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LinkedListItem<T>
    {
        public T Item;
        public LinkedListItem<T> Next;
        public LinkedListItem<T> Previous { get; set; }


        public LinkedListItem(T item)
        {
            Item = item;
            Next = null;
            Previous = null;
        }
    }
  
    public interface ILinkedList<T>
    {
        int Count { get; }

        void Add(T item);
        void AddFirst(T item);
        void AddLast(T item);
        void Clear();
        bool Remove(T item);
        T GetFirst();
        T Get(int i);
    }

    /// <summary>
    /// ŘAZENÍ V JEDNOSMĚRNÉM SPOJOVÉM SEZNAMU
    /// 1. BubbleSort (základní i s pamětí)
    /// 2. SelectSort -> pro vzestupné řazení lze vyhledat min a to umisťovat na začátek a zkracovat seznam
    /// 3. InsertSort - bez modifikace s binárního půlení
    /// </summary>
    public class LinkedList<T> : ILinkedList<T>
    {
        protected LinkedListItem<T> head;
        protected int count;

        public int Count { get { return count; } }

        public T GetFirst()
        {
            if (head != null) return head.Item;
            throw new Exception("The linked list is empty.");
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count) throw new ArgumentOutOfRangeException("index", "Index is out of range.");

            LinkedListItem<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Item;
        }

        public virtual void Add(T item)
        {
            throw new NotImplementedException();
        }

        public virtual void AddFirst(T item)
        {
            throw new NotImplementedException();
        }

        public virtual void AddLast(T item)
        {
            throw new NotImplementedException();
        }

        public virtual void Clear()
        {
            throw new NotImplementedException();
        }

        public virtual bool Remove(T item)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// ŘAZENÍ V JEDNOSMĚRNÉM SPOJOVÉM SEZNAMU
    /// 1. BubbleSort (základní i s pamětí)
    /// 2. SelectSort
    /// 3. InsertSort
    /// 4. ShakerSort
    /// </summary>
    public class LinkedListOneWay<T> : LinkedList<T>
    {
        public LinkedListOneWay()
        {
            head = null;
            count = 0;
        }

        public override void Add(T item)
        {
            LinkedListItem<T> newItem = new LinkedListItem<T>(item);
            if (head == null) head = newItem;
            else
            {
                LinkedListItem<T> current = head;
                while (current.Next != null) current = current.Next;
                current.Next = newItem;
            }
            count++;
        }

        public override void AddFirst(T item)
        {
            LinkedListItem<T> newItem = new LinkedListItem<T>(item);
            newItem.Next = head;
            head = newItem;
            count++;
        }

        public override void AddLast(T item)
        {
            LinkedListItem<T> newItem = new LinkedListItem<T>(item);
            if (head.Equals(null)) head = newItem;
            else
            {
                LinkedListItem<T> current = head;
                while (current != null) current = current.Next;
                current.Next = newItem;
            }
            count++;
        }

        public override bool Remove(T item)
        {
            if (head == null) return false;

            if (head.Item.Equals(item))
            {
                head = head.Next;
                count--;
                return true;
            }

            LinkedListItem<T> current = head;
            while (current.Next != null)
            {
                if (current.Next.Item.Equals(item))
                {
                    current.Next = current.Next.Next;
                    count--;
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public override void Clear()
        {
            head = null;
            count = 0;
        }
    }

    public class LinkedListBothWay<T> : LinkedList<T>
    {
        private LinkedListItem<T> tail;

        public LinkedListBothWay()
        {
            head = null;
            tail = null;
            count = 0;
        }


        public override void Add(T item)
        {
            LinkedListItem<T> newItem = new LinkedListItem<T>(item);
            if (head == null)
            {
                head = newItem;
                tail = newItem;
            }
            else
            {
                tail.Next = newItem;
                newItem.Previous = tail;
                tail = newItem;
            }
            count++;
        }

        public override void AddFirst(T item)
        {
            LinkedListItem<T> newItem = new LinkedListItem<T>(item);
            if (head == null)
            {
                head = newItem;
                tail = newItem;
            }
            else
            {
                newItem.Next = head;
                head.Previous = newItem;
                head = newItem;
            }
            count++;
        }

        public override void AddLast(T item)
        {
            LinkedListItem<T> newItem = new LinkedListItem<T>(item);
            if (head.Equals(null)) head = newItem;
            else
            {
                LinkedListItem<T> current = head;
                while (current != null) current = current.Next;
                current.Next = newItem;
            }
            count++;
        }

        public override bool Remove(T item)
        {
            LinkedListItem<T> current = head;
            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    if (current.Previous != null) current.Previous.Next = current.Next;
                    else head = current.Next;

                    if (current.Next != null) current.Next.Previous = current.Previous;
                    else tail = current.Previous;

                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public override void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
    }
}
