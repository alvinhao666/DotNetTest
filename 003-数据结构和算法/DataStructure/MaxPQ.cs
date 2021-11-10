using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class MaxPQ<E>:IQueue<E> where E:IComparable<E>
    {
        private MaxHeap<E> heap;

        public int Count { get { return heap.Count; } }

        public bool IsEmpty { get { return heap.IsEmpty; } }

        public MaxPQ(int capacity)
        {
            heap = new MaxHeap<E>(capacity);
        }

        public MaxPQ()
        {
            heap = new MaxHeap<E>();
        }

        public void Enqueue(E e)
        {
            heap.Insert(e);
        }

        public E Dequeue()
        {
           return heap.RemoveMax();
        }

        public E Peek()
        {
           return  heap.Max();
        }

        public override string ToString()
        {
            return heap.ToString();
        }
    }
}
