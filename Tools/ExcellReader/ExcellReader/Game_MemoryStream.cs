using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;
/// <summary>
/// 数据转换类:Byte Short Int Long Float Decimal Bool String
/// </summary>
public class Game_MemoryStream : MemoryStream
{
    public Game_MemoryStream() { }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    public Game_MemoryStream(byte[] buffer) : base(buffer) { }



    #region Short
    /// <summary>
    /// 从流中读取一个short数据
    /// </summary>
    /// <returns></returns>
    public short ReadShotFromStream()
    {
        byte[] arr = new byte[2];
        base.Read(arr, 0, 2);
        return BitConverter.ToInt16(arr, 0);
    }

    /// <summary>
    /// 把一个short写入流
    /// </summary>
    /// <param name="value"></param>
	public void WriteShortToStream(short value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region ushort
    /// <summary>
    /// 从流中读取一个ushort数据
    /// </summary>
    /// <returns></returns>
    public ushort ReadUShotFromStream()
    {
        byte[] arr = new byte[2];
        base.Read(arr, 0, 2);
        return BitConverter.ToUInt16(arr, 0);
    }

    /// <summary>
    /// 把一个ushort写入流
    /// </summary>
    /// <param name="value"></param>
	public void WriteUShortToStream(ushort value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region Int
    /// <summary>
    /// 从流中读取一个int数据
    /// </summary>
    /// <returns></returns>
    public int ReadIntFromStream()
    {
        byte[] arr = new byte[4];
        base.Read(arr, 0, 4);
        return BitConverter.ToInt32(arr, 0);
    }

    /// <summary>
    /// 把一个int写入流
    /// </summary>
    /// <param name="value">值</param>
	public void WriteIntToStream(int value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region UInt
    /// <summary>
    /// 从流中读取一个uint数据
    /// </summary>
    /// <returns></returns>
    public uint ReadUintFromStream()
    {
        byte[] arr = new byte[4];
        base.Read(arr, 0, 4);
        return BitConverter.ToUInt32(arr, 0);
    }

    /// <summary>
    /// 把一个uint写入流
    /// </summary>
    /// <param name="value"></param>
	public void WriteUIntToStream(uint value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region Long
    /// <summary>
    /// 从流中读取一个long数据
    /// </summary>
    /// <returns></returns>
    public long ReadLongFromStream()
    {
        byte[] arr = new byte[8];
        base.Read(arr, 0, 8);
        return BitConverter.ToInt64(arr, 0);
    }

    /// <summary>
    /// 把一个long写入流
    /// </summary>
    /// <param name="value"></param>
	public void WriteLongToStream(long value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region ULong
    /// <summary>
    /// 从流中读取一个ulong数据
    /// </summary>
    /// <returns></returns>
    public ulong ReadULongFromStream()
    {
        byte[] arr = new byte[8];
        base.Read(arr, 0, 8);
        return BitConverter.ToUInt64(arr, 0);
    }

    /// <summary>
    /// 把一个ulong写入流
    /// </summary>
    /// <param name="value"></param>
	public void WriteULongToStream(ulong value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region Float
    /// <summary>
    /// 从流中读取一个float数据
    /// </summary>
    /// <returns></returns>
    public float ReadFloatFromStream()
    {
        byte[] arr = new byte[4];
        base.Read(arr, 0, 4);
        return BitConverter.ToSingle(arr, 0);
    }

    /// <summary>
    /// 把一个float写入流
    /// </summary>
    /// <param name="value"></param>
	public void WriteFloatToStream(float value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region Double
    /// <summary>
    /// 从流中读取一个Double数据
    /// </summary>
    /// <returns></returns>
    public double ReadDoubleFromStream()
    {
        byte[] arr = new byte[8];
        base.Read(arr, 0, 8);
        return BitConverter.ToDouble(arr, 0);
    }

    /// <summary>
    /// 把一个double写入流
    /// </summary>
    /// <param name="value"></param>
	public void WriteDoubleToStream(double value)
    {
        byte[] arr = BitConverter.GetBytes(value);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

    #region Bool
    /// <summary>
    /// 从流中读取一个bool数据
    /// </summary>
    /// <returns></returns>
    public bool ReadBoolFromStream()
    {
        return base.ReadByte() == 1;
    }

    /// <summary>
    /// 把一个bool写入流
    /// </summary>
    /// <param name="value"></param>
	public void WriteBoolToStream(bool value)
    {
        base.WriteByte((byte)(value == true ? 1 : 0));
    }
    #endregion

    #region UTF8String
    /// <summary>
    /// 从流中读取String数组
    /// </summary>
    /// <returns></returns>
    public string ReadUTF8Str()
    {
        ushort length = this.ReadUShotFromStream();
        byte[] arr = new byte[length];
        base.Read(arr, 0, length);
        return Encoding.UTF8.GetString(arr);
    }

    /// <summary>
    /// 把string数组写入流中
    /// </summary>
    /// <param name="str"></param>
    public void WriteUTF8Str(string str)
    {
        byte[] arr = Encoding.UTF8.GetBytes(str);
        if (arr.Length > 65535)
        {
            throw new InvalidCastException("字符串超出范围");
        }
        this.WriteUShortToStream((ushort)arr.Length);
        base.Write(arr, 0, arr.Length);
    }
    #endregion

}
