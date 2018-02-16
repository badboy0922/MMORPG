//======================================================
//作     者：Ning	日   期： 2018-02-14 18:06:45
//Unity版本：5.6.4f1
//备     注：角色状态的抽象基类
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色状态的抽象基类
/// </summary>
public abstract class RoleStateAbstract
{
    /// <summary>
    /// 当前角色有限状态机管理器
    /// </summary>
    public RoleFSMMgr CurrRoleFSMMgr { get; private set; }

    /// <summary>
    /// 当前动画状态信息
    /// </summary>
    public AnimatorStateInfo CurrAnimatorStateInfo { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="roleFSMMgr"></param>
    public RoleStateAbstract(RoleFSMMgr roleFSMMgr)
    {
        CurrRoleFSMMgr = roleFSMMgr;
    }

    /// <summary>
    /// 进入状态
    /// </summary>
    public virtual void OnEnter() { }

    /// <summary>
    /// 执行状态
    /// </summary>
    public virtual void OnUpdate() { }

    /// <summary>
    /// 离开状态
    /// </summary>
    public virtual void OnLeave() { }
}
