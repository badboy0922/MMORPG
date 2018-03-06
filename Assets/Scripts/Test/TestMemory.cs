//======================================================
//作     者：Ning	日   期： 2018-02-28 00:26:22
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMemory : MonoBehaviour
{
    void Start()
    {
        Item item = new Item() { Id = 1, Name = "测试" };

        byte[] arr = null;
        using (MMO_MemoryStream ms = new MMO_MemoryStream())
        {
            ms.WriteInt(item.Id);
            ms.WriteUTF8String(item.Name);
            arr = ms.ToArray();
        }

        //if (arr != null)
        //{
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        Debug.Log(string.Format("{0} {1}", i, arr[i]));
        //    }
        //}

        Item item2 = new Item();

        using (MMO_MemoryStream ms = new MMO_MemoryStream(arr))
        {
            item2.Id = ms.ReadInt();
            item2.Name = ms.ReadUTF8String();
        }
        Debug.Log(string.Format("{0} {1}", item2.Id, item2.Name));

    }

    void Update()
    {

    }
}

public class Item
{
    public int Id;
    public string Name;
}
