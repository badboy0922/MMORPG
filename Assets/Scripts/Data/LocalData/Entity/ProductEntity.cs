//======================================================
//作     者：Ning	日   期： 2018-03-04 05:05:12
//Unity版本：5.6.4f1
//备     注：商品实体
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 商品实体
/// </summary>
public class ProductEntity : AbstractEntity
{
    /// <summary>
    /// 商品编号
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 商品名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 价格
    /// </summary>
    public float Price { get; set; }

    /// <summary>
    /// 图片名称
    /// </summary>
    public string PicName { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Desc { get; set; }
}
