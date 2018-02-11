//======================================================
//作     者：Ning	日   期： 2018-02-10 00:40:26
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region SceneType 场景类型
/// <summary>
/// 场景类型
/// </summary>
public enum SceneType
{
    LogOn,
    City
}
#endregion

#region WindowUIType 窗口类型
/// <summary>
/// 窗口类型
/// </summary>
public enum WindowUIType
{
    /// <summary>
    /// 未设置
    /// </summary>
    None,
    /// <summary>
    /// 登陆
    /// </summary>
    LogOn,
    /// <summary>
    /// 注册
    /// </summary>
    Reg
}
#endregion

#region WindowUIContainerType UI容器类型
/// <summary>
/// UI容器类型
/// </summary>
public enum WindowUIContainerType
{
    /// <summary>
    /// 左上
    /// </summary>
    TopLeft,
    /// <summary>
    /// 右上
    /// </summary>
    TopRight,
    /// <summary>
    /// 左下
    /// </summary>
    BottomLeft,
    /// <summary>
    /// 右下
    /// </summary>
    BottomRight,
    /// <summary>
    /// 中心
    /// </summary>
    Center
}
#endregion

#region WindowShowStyle 窗口的打开方式类型
/// <summary>
/// 窗口的打开方式类型
/// </summary>
public enum WindowShowStyle
{
    /// <summary>
    /// 正常打开
    /// </summary>
    Normal,
    /// <summary>
    /// 从中间放大
    /// </summary>
    CenterToBig,
    /// <summary>
    /// 从上往下
    /// </summary>
    FromTop,
    /// <summary>
    /// 从下往上
    /// </summary>
    FromDown,
    /// <summary>
    /// 从左向右
    /// </summary>
    FromLeft,
    /// <summary>
    /// 从右向左
    /// </summary>
    FromRight
}
#endregion

