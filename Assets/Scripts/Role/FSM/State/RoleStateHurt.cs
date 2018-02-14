//======================================================
//作     者：Ning	日   期： 2018-02-14 18:09:02
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 受伤状态
/// </summary>
public class RoleStateHurt : RoleStateAbstract
{
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="roleFSMMgr">有限状态机管理器</param>
    public RoleStateHurt(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {
    }

    /// <summary>
    /// 实现基类 进入状态
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
    }

    /// <summary>
    /// 实现基类 执行状态
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    /// <summary>
    /// 实现基类 离开状态
    /// </summary>
    public override void OnLeave()
    {
        base.OnLeave();
    }
}
