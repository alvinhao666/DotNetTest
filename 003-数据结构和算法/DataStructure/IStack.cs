namespace DataStructure
{
    interface IStack<E>
    {
        int Count { get; }

        bool IsEmpty { get; }

        void Push(E e);

        E Pop();

        E Peek();
    }
}
