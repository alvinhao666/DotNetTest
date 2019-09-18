using System;

namespace 建议17_多数情况下使用foreach进行循环遍历
{
    class Program
    {
        static void Main(string[] args)
        {
            //使用接口IMyEnumerable代替MyList
            MyList list = new MyList();
            //得到迭代器，在循环中针对迭代器编码，而不是集合MyList
            IMyEnumerator enumerator2 = new MyEnumerator(list);
            for (int i = 0; i < list.Count; i++)
            {
                object current = enumerator2.Current;
                enumerator2.MoveNext();
            }

            //foreach (var current in list)
            //{
            //    //省略了 object current = enumerator.Current;
            //}

            //while (enumerator.MoveNext())
            //{
            //    object current = enumerator.Current;
            //}

            Console.WriteLine();
        }
    }

    /// <summary>
    /// 要求全部迭代器显示
    /// </summary>
    interface IMyEnumerator
    {
        bool MoveNext();
        object Current { get; }
    }
    /// <summary>
    /// 要求所有的集合实现该接口
    /// 这样一来，客户端就可以针对该接口编码，
    /// 而无须关注具体的实现
    /// </summary>
    interface IMyEnumerable
    {
        IMyEnumerator GetEnumerator();
        int Count { get; }
    }

    class MyList : IMyEnumerable
    {
        object[] items = new object[10];
        IMyEnumerator myEnumerator;

        public object this[int i]
        {
            get { return items[i]; }
            set { this.items[i] = value; }
        }

        public int Count
        {
            get { return items.Length; }
        }

        public IMyEnumerator GetEnumerator()
        {
            if (myEnumerator == null)
            {
                myEnumerator = new MyEnumerator(this);
            }
            return myEnumerator;
        }
    }

    class MyEnumerator : IMyEnumerator
    {
        int index = 0;
        MyList myList;
        public MyEnumerator(MyList myList)
        {
            this.myList = myList;
        }

        public bool MoveNext()
        {
            if (index + 1 > myList.Count)
            {
                index = 1;
                return false;
            }
            else
            {
                index++;
                return true;
            }
        }

        public object Current
        {
            get { return myList[index - 1]; }
        }
    }
}
