//======================================================
//作     者：Ning	日   期： 2018-02-10 00:30:31
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectUtil
{
    /// <summary>
    /// 获取或创建组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T GetOrCreatComponent<T>(this GameObject obj) where T : MonoBehaviour
    {
        T t = obj.GetComponent<T>();
        if (t == null)
        {
            t = obj.AddComponent<T>();
        }
        return t;
    }
}
