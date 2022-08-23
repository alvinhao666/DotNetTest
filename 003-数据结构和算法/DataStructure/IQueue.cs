﻿namespace DataStructure
{
    //队列接口
    interface IQueue<E>
    {
        int Count { get; }

        bool IsEmpty { get; }

        void Enqueue(E e);

        E Dequeue();

        E Peek();
    }
}
