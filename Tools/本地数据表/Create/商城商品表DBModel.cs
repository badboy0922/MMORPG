
//===================================================
//作    者：边涯  http://www.u3dol.com  QQ群：87481002
//创建时间：2018-03-07 09:12:09
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// 商城商品表数据管理
/// </summary>
public partial class 商城商品表DBModel : AbstractDBModel<商城商品表DBModel, 商城商品表Entity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    protected override string FileName { get { return "商城商品表.data"; } }

    /// <summary>
    /// 创建实体
    /// </summary>
    /// <param name="parse"></param>
    /// <returns></returns>
    protected override 商城商品表Entity MakeEntity(GameDataTableParser parse)
    {
        商城商品表Entity entity = new 商城商品表Entity();
        entity.Id = parse.GetFieldValue("Id").ToInt();
        entity.Name = parse.GetFieldValue("Name");
        entity.Price = parse.GetFieldValue("Price").ToFloat();
        entity.PicName = parse.GetFieldValue("PicName");
        entity.Desc = parse.GetFieldValue("Desc");
        return entity;
    }
}
