//======================================================
//作     者：Ning	日   期： 2018-02-14 18:08:20
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 待机状态
/// </summary>
public class RoleStateIdle : RoleStateAbstract
{
    /// <summary>
    /// 构造方法
    /// </summary>
    /// <param name="roleFSMMgr">有限状态机管理器</param>
    public RoleStateIdle(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {
    }

    /// <summary>
    /// 实现基类 进入状态
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetBool("ToIdleNormal", true);
        CurrRoleFSMMgr.CurrRoleCtrl.Animator.SetInteger("CurrState", 1);
    }

    /// <summary>
    /// 实现基类 执行状态
    /// </summary>
    public override void OnUpdate()
    {
        base.OnUpdate();

        AnimatorStateInfo info = CurrRoleFSMMgr.CurrRoleCtrl.Animator.GetCurrentAnimatorStateInfo(0);
    }

    /// <summary>
    /// 实现基类 离开状态
    /// </summary>
    public override void OnLeave()
    {
        base.OnLeave();
    }
}
