using System;

namespace Byte
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 有符号
            
            var a = sbyte.MinValue;  //-128  -2^7 ~ (2^7) -1  8字节
            var b = sbyte.MaxValue;  //127
            Console.WriteLine(a);
            Console.WriteLine(b);
            

            var c = short.MinValue; //-32768  -2^15 ~ (2^15) -1  //16字节
            var d = short.MaxValue; //32767 
            Console.WriteLine(c);
            Console.WriteLine(d);
            
            var e = int.MinValue;  // -2^31 ~ (2^31) -1  //32字节
            var f = int.MaxValue; 
            Console.WriteLine(e);
            Console.WriteLine(f);
            
            var g = long.MinValue;  // -2^63 ~ (2^63) -1  //64字节
            var h = long.MaxValue; 
            Console.WriteLine(g);
            Console.WriteLine(h);

            #endregion


            #region 无符号
            
            var a2 = byte.MinValue;  //0  0 ~ (2^8) -1  8字节
            var b2 = byte.MaxValue;  //255
            Console.WriteLine(a2);
            Console.WriteLine(b2);
            
            var c2 = ushort.MinValue; //-32768  0 ~ (2^16) -1  //16字节
            var d2 = ushort.MaxValue; //32767 
            Console.WriteLine(c2);
            Console.WriteLine(d2);
            
            var e2 = uint.MinValue;  // 0 ~ (2^32) -1  //32字节
            var f2 = uint.MaxValue; 
            Console.WriteLine(e2);
            Console.WriteLine(f2);
            
            var g2 = ulong.MinValue;  // 0 ~ (2^64) -1  //64字节
            var h2 = ulong.MaxValue; 
            Console.WriteLine(g2);
            Console.WriteLine(h2);
            
            #endregion
            

            
            Console.ReadKey();
        }
    }
}