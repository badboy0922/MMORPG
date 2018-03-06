using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcellReader
{
    static class XorScaleMgr
    {
        public static byte[] xorScale;


        /// <summary>
        /// 异或因子长度
        /// </summary>
        /// <param name="length"></param>
        public static void SetXorScaleLength(int length)
        {
            xorScale = new byte[length];
        }


        /// <summary>
        /// 异或因子设置值
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="index">索引</param>
        public static void SetXorScaleValue(string value,int index)
        {
            xorScale.SetValue(Convert.ToByte(value), index);
        }


        public static void SetToOtherClass()
        {

        }
    }
}
