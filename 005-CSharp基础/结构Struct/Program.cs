using System;

namespace 结构Struct
{
    class Program
    {
        //结构体（struct）是类(class)的轻量级版本。结构体是值类型，可用于创建行为类似于内置类型的对象。 https://www.cnblogs.com/ittranslator/p/13664383.html?utm_source=gold_browser_extension
        static void Main(string[] args)
        {
            //结构体不能有默认构造函数(无参构造函数)或析构函数，构造函数中必须给所有字段赋值。
            //结构体可以在不使用 new 操作符的情况下实例化。
        }
    }

    public struct Coords
    {
        public double x;
        public double y;

        //public Coords() //错误，不允许无参构造函数
        //{
        //    this.x = 3;
        //    this.y = 4;
        //}

        //public Coords(double x) //错误，构造函数中必须给所有字段赋值
        //{
        //    this.x = x;
        //}

        //public Coords(double x) //这个是正确的
        //{
        //    this.x = x;
        //    this.y = 4;
        //}

        public Coords(double x, double y) //这个是正确的
        {
            this.x = x;
            this.y = y;
        }
}

    //结构体中不允许实例属性或字段包含初始值设定项。但是，结构体允许静态属性或字段包含初始值设定项。
    //public struct Coords
    //{
    //    public double x = 4; //错误, 结构体中初始化器不允许实例字段设定初始值  
    //    public static double y = 5; // 正确
    //    public static double z { get; set; } = 6; // 正确
    //}
}
