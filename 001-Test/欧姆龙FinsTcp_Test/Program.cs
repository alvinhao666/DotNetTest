using Newtonsoft.Json;
using OmronFinsTCP.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 欧姆龙FinsTcp_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EtherNetPLC _etherNetPLC = new EtherNetPLC();
            try
            {
                if (_etherNetPLC.Link("127.0.0.1", 9600, 1000) < 0)
                {
                    Console.WriteLine($"Failed to connect to plc!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to connect to plc!");

                Console.WriteLine(e.ToString());
            }
            //if (_etherNetPLC.ReadWord(OmronFinsTCP.Net.PlcMemory.DM, 305, out short retData) == 0)
            //{
            //    var bytes = BitConverter.GetBytes(retData);
            //}

            //if (_etherNetPLC.ReadWords(OmronFinsTCP.Net.PlcMemory.DM, 305, 4, out short[] retDatas) == 0)
            //{
            //    //var bytes = BitConverter.GetBytes(retDatas[0]);
            //}


            if (_etherNetPLC?.GetBitState(OmronFinsTCP.Net.PlcMemory.DM, "300.0", out short retData1) == 0)
            {
                //var bytes = BitConverter.GetBytes(retData);
            }

            if (_etherNetPLC?.GetBitState(OmronFinsTCP.Net.PlcMemory.DM, "305.2", out short retData2) == 0)
            {
                //var bytes = BitConverter.GetBytes(retData2);
            }

            if (_etherNetPLC?.GetBitState(OmronFinsTCP.Net.PlcMemory.DM, "305.3", out short retData3) == 0)
            {
                //var bytes = BitConverter.GetBytes(retData3);
            }

            //string address = "D00305.2";

            //string[] splits = address.Substring(1).Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            //ushort addr = ushort.Parse(splits[0]);
            //var addrBytes = BitConverter.GetBytes(addr);
            //var addr1 = addrBytes[1];
            //var addr0 = addrBytes[0];

            //if (splits.Length > 1)
            //{
            //    var addr2 = byte.Parse(splits[1]);
            //    if (addr2 > 15)
            //    {

            //    }
            //}

            //string s = "[True,True,True,True,True,True,True,True,True,True,True,True,True,True,True,True,True,True,True,True,True,True,True]";

            string s = "[True,True,True,True,True,True,True,True,True,True,True,True,True,True,True,True]";

            var boolArray = JsonConvert.DeserializeObject<bool[]>(s.ToLower());

            var bytesArray = Convert_BoolArray_To_ByteArray(boolArray);

            Console.WriteLine("bytesArray :" + JsonConvert.SerializeObject(bytesArray.Select(a=>(int)a)));

            var shortArray = Convert_ByteArray_ToShort_Array(bytesArray);

            Console.WriteLine("shortArray :" + JsonConvert.SerializeObject(shortArray));

            Console.ReadKey();
        }


        private static byte[] Convert_BoolArray_To_ByteArray(bool[] bools)
        {
            int len = bools.Length;
            int bytes = len >> 3;
            if ((len & 0x07) != 0) ++bytes;
            byte[] arr2 = new byte[bytes];
            for (int i = 0; i < bools.Length; i++)
            {
                if (bools[i])
                    arr2[i >> 3] |= (byte)(1 << (i & 0x07));
            }
            return arr2;
        }

        private static short[] Convert_ByteArray_ToShort_Array(byte[] bytes)
        {
            short[] samples = new short[bytes.Length];
            Buffer.BlockCopy(bytes, 0, samples, 0, bytes.Length);
            return samples;
        }

    }
}
