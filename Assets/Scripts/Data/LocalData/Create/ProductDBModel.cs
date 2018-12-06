using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 商品数据管理
///     读取数据
/// </summary>
public partial class ProductDBModel : AbstractDBModel<ProductDBModel, ProductEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    protected override string FileName { get { return "Product.data"; } }

    /// <summary>
    ///  创建实体
    /// </summary>
    /// <param name="parse"></param>
    /// <returns></returns>
    protected override ProductEntity MakeEntity(GameDataTableParser parse)
    {
        ProductEntity entity = new ProductEntity();
        entity.Id = parse.GetFieldValue("Id").ToInt();
        entity.Name = parse.GetFieldValue("Name");
        entity.Price = parse.GetFieldValue("Price").ToFloat();
        entity.PicName = parse.GetFieldValue("PicName");
        entity.Desc = parse.GetFieldValue("Desc");
        return entity;
    }
}
