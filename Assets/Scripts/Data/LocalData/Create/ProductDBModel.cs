using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ʒ���ݹ���
///     ��ȡ����
/// </summary>
public partial class ProductDBModel : AbstractDBModel<ProductDBModel, ProductEntity>
{
    /// <summary>
    /// �ļ�����
    /// </summary>
    protected override string FileName { get { return "Product.data"; } }

    /// <summary>
    ///  ����ʵ��
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
