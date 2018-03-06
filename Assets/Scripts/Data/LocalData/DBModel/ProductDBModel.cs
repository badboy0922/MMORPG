//======================================================
//作     者：Ning	日   期： 2018-03-04 05:15:26
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 商品诗句管理
/// </summary>
public class ProductDBModel : IDisposable
{
    private List<ProductEntity> lst;

    private ProductDBModel()
    {
        lst = new List<ProductEntity>();
        Load();
    }

    private static ProductDBModel instance;
    public static ProductDBModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ProductDBModel();
            }
            return instance;
        }
    }

    private void Load()
    {
        using (GameDataTableParser parse = new GameDataTableParser(""))
        {
            while (!parse.Eof)
            {
                ProductEntity entity = new ProductEntity();

                entity.Id = parse.GetFieldValue("Id").ToInt();
                entity.Name = parse.GetFieldValue("Name");
                entity.Price = parse.GetFieldValue("Price").ToFloat();
                entity.PicName = parse.GetFieldValue("PicName");
                entity.Desc = parse.GetFieldValue("Desc");

                lst.Add(entity);
            }
        }
    }

    public List<ProductEntity> GetList()
    {
        return lst;
    }

    public void Dispose()
    {
        lst.Clear();
        lst = null;
    }
}
