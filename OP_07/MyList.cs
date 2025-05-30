using System;
using System.Collections;
using System.Collections.Generic;

namespace OP_07
{
    public class MyDoubleLinkedList<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Value;
            public Node? Next;
            public Node? Previous;

            public Node(T value)
            {
                Value = value;
            }
        }
        private Node? head;
        private Node? tail;
        private int count;
        public int Count => count;
        public void AddFirst(T value)
        {
            var node = new Node(value);
            if (head == null)
            {
                head = tail = node;
            }
            else
            {
                node.Next = head;
                head.Previous = node;
                head = node;
            }
            count++;
        }
        public void AddLast(T value)
        {
            var node = new Node(value);
            if (tail == null)
            {
                head = tail = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }
            count++;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                var current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException(); 
            }
            var current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                head = current.Next;
            }
            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                tail = current.Previous;
            }
            count--;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public T FindFirstBelowAverage()
        {
            if (typeof(T) != typeof(double))
            {
                throw new InvalidOperationException("This operation only supports double type.");
            }
            double sum = 0;
            int n = 0;
            foreach (var item in this)
            {
                sum += Convert.ToDouble(item);
                n++;
            }
            double average = sum / n;
            foreach (var item in this)
            {
                if (Convert.ToDouble(item) < average)
                {
                    return item;
                }
            }
            throw new InvalidOperationException("No element below average found.");
        }
        public double SumAfterMax()
        {
            if (typeof(T) != typeof(double))
            {
                throw new InvalidOperationException("This operation only supports double type.");
            }
            double max = double.MinValue;
            foreach (var item in this)
            {
                double value = Convert.ToDouble(item);
                if (value > max)
                {
                    max = value;
                }
            }
            bool foundMax = false;
            double sum = 0;
            foreach (var item in this)
            {
                if (foundMax)
                {
                    sum += Convert.ToDouble(item);
                }
                if (Convert.ToDouble(item) == max)
                {
                    foundMax = true;
                }
            }
            return sum;
        }
        public MyDoubleLinkedList<T> GetListAboveValue(double threshold)
        {
            if (typeof(T) != typeof(double))
            {
                throw new InvalidOperationException("This operation only supports double type.");
            }
            var newList = new MyDoubleLinkedList<T>();
            foreach (var item in this)
            {
                if (Convert.ToDouble(item) > threshold)
                {
                    newList.AddLast(item);
                }
            }
            return newList;
        }
        public void RemoveBeforeMax()
        {
            if (typeof(T) != typeof(double))
            {
                throw new InvalidOperationException("This operation only supports double type.");
            }
            double max = double.MinValue;
            var current = head;
            while (current != null)
            {
                double value = Convert.ToDouble(current.Value);
                if (value > max)
                {
                    max = value;
                }
                current = current.Next;
            }
            current = head;
            while (current != null && Convert.ToDouble(current.Value) != max)
            {
                var next = current.Next;
                RemoveAt(0);
                current = next;
            }
        }
    }
}
