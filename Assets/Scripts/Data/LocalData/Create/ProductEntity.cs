using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 商品实体
/// </summary>
public partial class ProductEntity : AbstractEntity
{
    /// <summary>
    /// 商品名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 价格
    /// </summary>
    public float Price { get; set; }

    /// <summary>
    /// 商品图片名称
    /// </summary>
    public string PicName { get; set; }

    /// <summary>
    /// 描述
    /// </summary>
    public string Desc { get; set; }
}
