using System;
using System.Collections;
using System.Linq;
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

            var bytesarry = new byte[] { 0, 1, 0, 0, 0, 0, 0, 0, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


            var ST2 = ByteToHex(bytesarry);


            var str1 = BitConverter.ToString(bytesarry);


            var sss = Encoding.ASCII.GetString(bytesarry);

            var s = "";
            for(var i = 0; i < 32; i++)
            {
                s += "00 ";
            }

            bytesarry = new byte[] { 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31 };

            var value2 = Encoding.ASCII.GetString(bytesarry);

            var value2Int = int.Parse(value2);

            var bs = Encoding.ASCII.GetBytes(value2Int.ToString().PadLeft(10,'0'));


            bytesarry = new byte[] { 0x01 };

            Console.WriteLine(bytesarry[0] == 1);


            var ss = BitConverter.GetBytes((ushort)4);

            var ssss = Ushort2HexBytes(4);

            Console.ReadKey();
        }



        private static byte[] Ushort2HexBytes(ushort value)
        {
            return BitConverter.GetBytes(value).Reverse().ToArray();
        }

        public static string ByteToHex(byte[] Bytes)
        {
            string str = string.Empty;
            foreach (byte Byte in Bytes)
            {
                str += String.Format("{0:X2}", Byte) + " ";
            }
            return str.Trim();
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