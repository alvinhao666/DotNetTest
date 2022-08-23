namespace 反射
{
    public class Demo1
    {
        public string Name { get; set; }
    }

    public delegate void DeA();
    public delegate void DeB<T>(T t);

    public class ClassC<T>
    {
        public ClassC(T t) { }
    }
}
