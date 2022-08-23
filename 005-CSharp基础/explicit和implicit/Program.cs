namespace explicit和implicit
{

    ////explicit：代表用来声明显示自定义类型的转换
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        A a = new A();
    //        a.age = 10;
    //        B b = (B)a;

    //    }
    //}


    //class A
    //{
    //    public int age;
    //}
    //class B
    //{
    //    public string age;
    //    public B(string age)
    //    {
    //        this.age = age;
    //    }
    //    public static explicit operator B(A a)
    //    {
    //        return new B(a.age.ToString());
    //    }
    //}

    //implicit：代表用来声明隐式自定义类型的转换
    class Program
    {
        static void Main(string[] args)
        {
            B b2 = new B("100");
            A a2 = b2; //将B隐式转换为A
        }
    }

    //同样先定义A、B俩个类，为B声明一个隐式转换
    class A
    {
        public int age;
        public A(int age)
        {
            this.age = age;
        }
    }
    class B
    {
        public string age;
        public B(string age)
        {
            this.age = age;
        }

        public static implicit operator A(B b)
        {
            return new A(int.Parse(b.age));
        }
    }

}
