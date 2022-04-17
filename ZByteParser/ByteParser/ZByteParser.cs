﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ByteParser
{
    public static class ZByteParser
    {
        public static string GetRawBits(byte data)
        {
            string value = "";
            int[] Input_Data = new int[8];
            for (int i = 0; i < 8; i++)
            {
                Input_Data[i] = Convert.ToInt32(Getbit(data, i));
            }
            value = Input_Data[7] + " " + Input_Data[6] + " " + Input_Data[5] + " " + Input_Data[4] + " " + Input_Data[3] + " " + Input_Data[2] + " " + Input_Data[1] + " " + Input_Data[0] + " ";
            return value;
        }
        public static bool Getbit(byte data, int indxOfBit)
        {
            bool value = false;
            int temp;
            temp = (data >> indxOfBit) & 1;
            value = Convert.ToBoolean(temp);
            return value;
        }
        public static int Getbits(byte data, int StartIndx, int EndIndx)
        {
            int value = 0;
            value = (data >> StartIndx) & ((int)Math.Pow(2, (EndIndx - StartIndx + 1)) - 1);
            return value;
        }
        public static byte GetbitsMSB(byte data, int StartIndx, int EndIndx)
        {
            int[] Input_Data = new int[8];
            int[] temp = new int[EndIndx - StartIndx + 1];
            int value = 0;
            for (int i = 0; i < 7; i++)
            {
                Input_Data[i] = Convert.ToInt32(Getbit(data, i));
            }
            for (int i = 0; i < EndIndx - StartIndx + 1; i++)
            {
                temp[EndIndx - i] = Input_Data[i];
                value += temp[EndIndx - i] << (EndIndx - i);
            }
            return Convert.ToByte(value);
        }
        public static byte InsertBitIntoByte(byte input, int index, bool value)
        {
            int d = 0;
            int temp = (int)Math.Pow(2, index);
            d = ~(temp);
            input &= (byte)d;
            if (value)
            {
                input += (byte)temp;
            }
            return input;
        }
        public static byte InsertNumberIntoByte(byte input, int index, int value)
        {
            int d = 0;
            d = value << index;
            input += Convert.ToByte(d);
            return input;
        }
        //must be edited
        public static Byte[] Getbyte<T>(byte[] Input_Data, int idx_Destination, T Value, out int N_idx)
        {
            if (typeof(T) == typeof(double))
            {
                var Amghezi = Convert.ToDouble(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }
            if (typeof(T) == typeof(Int16))
            {
                var Amghezi = Convert.ToInt16(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }
            if (typeof(T) == typeof(Int32))
            {
                var Amghezi = Convert.ToInt32(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }
            if (typeof(T) == typeof(Int64))
            {
                var Amghezi = Convert.ToInt64(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }
            if (typeof(T) == typeof(UInt16))
            {
                var Amghezi = Convert.ToUInt16(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }
            if (typeof(T) == typeof(UInt32))
            {
                var Amghezi = Convert.ToUInt32(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }
            if (typeof(T) == typeof(UInt64))
            {
                var Amghezi = Convert.ToUInt64(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }
            if (typeof(T) == typeof(bool))
            {
                var Amghezi = Convert.ToBoolean(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }
            if (typeof(T) == typeof(float))
            {
                var Amghezi = Convert.ToSingle(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }
            if (typeof(T) == typeof(Byte))
            {
                var Amghezi = Convert.ToByte(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }
            if (typeof(T) == typeof(SByte))
            {
                var Amghezi = Convert.ToSByte(Value);
                Array.Copy(BitConverter.GetBytes(Amghezi), 0, Input_Data, idx_Destination, BitConverter.GetBytes(Amghezi).Length);
                idx_Destination += BitConverter.GetBytes(Amghezi).Length;
            }



            N_idx = idx_Destination;
            return Input_Data;
        }
    }
}
