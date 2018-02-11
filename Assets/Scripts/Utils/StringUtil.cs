//======================================================
//作     者：Ning	日   期： 2018-02-10 00:27:55
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class StringUtil
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int ToInt(this string str)
    {
        int temp = 0;
        int.TryParse(str, out temp);
        return temp;
    }
}
