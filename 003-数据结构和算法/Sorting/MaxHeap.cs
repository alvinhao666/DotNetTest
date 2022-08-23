using System;
using System.Text;

namespace Sorting
{
    //最大堆
    class MaxHeap<E> where E : IComparable<E>
    {
        private E[] heap;
        private int N;

        public MaxHeap(int capacity)
        {
            heap = new E[capacity + 1];
            N = 0;
        }

        public MaxHeap() : this(10) { }

        public int Count { get { return N; } }

        public bool IsEmpty { get { return N == 0; } }

        //往堆中插入元素
        public void Insert(E e)
        {
            if (N == (heap.Length - 1))
                ResetCapacity(heap.Length * 2);

            heap[N + 1] = e;
            N++;
            Swim(N);
        }

        //删除堆顶元素
        public E RemoveMax()
        {
            if (IsEmpty)
                throw new ArgumentException("堆为空！");

            Swap(1, N);
            E max = heap[N];
            heap[N] = default(E);
            N--;

            Sink(1);

            if (N == (heap.Length - 1) / 4)
                ResetCapacity(heap.Length / 2);

            return max;
        }

        //查看最大值
        public E Max()
        {
            if (IsEmpty)
                throw new ArgumentException("堆为空！");

            return heap[1];
        }

        //输出数组类的信息
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append("[");
            for (int i = 1; i <= N; i++)
            {
                res.Append(heap[i]);
                if (i != N)
                    res.Append(", ");
            }
            res.Append("]");
            return res.ToString();
        }

        //调整数组容量的大小
        private void ResetCapacity(int newCapacity)
        {
            E[] newHeap = new E[newCapacity];
            for (int i = 1; i <= N; i++)
                newHeap[i] = heap[i];

            heap = newHeap;
        }

        //元素上游
        private void Swim(int k)
        {
            while (k > 1 && heap[k].CompareTo(heap[k / 2]) > 0)
            {
                Swap(k, k / 2);
                k = k / 2;
            }
        }

        //元素下沉
        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;

                if (j + 1 <= N && heap[j + 1].CompareTo(heap[j]) > 0) j++;

                if (heap[k].CompareTo(heap[j]) >= 0) break;

                Swap(k, j);

                k = j;
            }
        }

        private void Swap(int i, int j)
        {
            E e = heap[i];
            heap[i] = heap[j];
            heap[j] = e;
        }
    }
}
