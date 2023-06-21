using System;
using System.Collections;
using System.Text;

namespace ByteTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //byte[] msg = new byte[] { 0,0x01,1,3,4,5,6,8,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

            //int msgLen = 32;
            //int len = msg.Length / msgLen;

            //for (int i = 0; i < len; i++)
            //{
            //    byte[] data = new byte[msgLen];
            //    Array.Copy(msg, msgLen * i, data, 0, msgLen);

            //    foreach (byte b in data)
            //    {
            //        Console.WriteLine(b);
            //    }

            //    string str_Data = Encoding.ASCII.GetString(data);

            //    Console.WriteLine("ASCII  " + str_Data[1]);
            //}

            //var bytes = BitConverter.GetBytes(short.MaxValue);

            bool[] myBools = new bool[6] { true, false, true, false,true,true };
           
            var value = BitsToWord(myBools);

            Console.WriteLine(value);


            Console.ReadKey();
        }



        public static short BitsToWord(bool[] bits)
        {
            short result = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i])
                    result |= (short)(1 << i);
            }
            return result;
        }

    }
}