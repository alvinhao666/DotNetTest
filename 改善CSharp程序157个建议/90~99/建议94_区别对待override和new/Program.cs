using System;

namespace 建议94_区别对待override和new
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape s = new Circle(); //Circle类override父类的MethodVirtual，所以即使子类转型为Shape，调用的还是子类方法：
            s.MethodVirtual();
            s.Method();
            
            Circle s2 = new Circle();
            s2.MethodVirtual();
            s2.Method();
            
            Shape s3 = new Triangle(); //因为子类应经new了父类的方法，故子类方法和基类方法完全没有关系了，只要s被转型为Shape，针对s调用搞得都是父类方法。
            s3.MethodVirtual();
            s3.Method();
            
            Triangle triangle = new Triangle();
            triangle.MethodVirtual();
            triangle.Method();
            
            
            Shape s4=new Diamond(); //Diamond包含了两个和基类一模一样的方法，并且没有额外的修饰符。这在编译器中会提出警示。但是如果选择忽略这些警示，程序还是一样可以运行。编译器会默认new的效果，所以输出和显示设置为new时一样。
            s4.MethodVirtual();
            s4.Method();
            
            Diamond s5 = new Diamond();
            s5.MethodVirtual();
            s5.Method();

            Console.ReadKey();
        }
    }
    
    
    public class Shape
    {
        public virtual void MethodVirtual()
        {
            Console.WriteLine("base MethodVirtual call");
        }

        public void Method()
        {
            Console.WriteLine("base Method call");
        }
    }
    
    
    class Circle : Shape
    {
        public override void MethodVirtual()
        {
            Console.WriteLine("circle override MethodVirtual");
        }
    }

    class Rectangle : Shape
    {

    }

    class Triangle : Shape
    {
        public new void MethodVirtual()
        {
            Console.WriteLine("triangle new MethodVirtual");
        }

        public new void Method()
        {
            Console.WriteLine("triangle new Method");
        }
    }

    class Diamond : Shape
    {
        public void MethodVirtual()
        {
            Console.WriteLine("Diamond default MethodVirtual");
        }

        public void Method()
        {
            Console.WriteLine("Diamond default Method");
        }
    }

}