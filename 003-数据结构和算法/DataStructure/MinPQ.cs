using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class MinPQ<E> : IQueue<E> where E : IComparable<E>
    {
        private MinHeap<E> heap;

        public int Count { get { return heap.Count; } }

        public bool IsEmpty { get { return heap.IsEmpty; } }

        public MinPQ(int capacity)
        {
            heap = new MinHeap<E>(capacity);
        }

        public MinPQ()
        {
            heap = new MinHeap<E>();
        }

        public void Enqueue(E e)
        {
            heap.Insert(e);
        }

        public E Dequeue()
        {
            return heap.RemoveMin();
        }

        public E Peek()
        {
            return heap.Min();
        }

        public override string ToString()
        {
            return heap.ToString();
        }
    }
}
