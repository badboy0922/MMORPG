//======================================================
//作     者：Ning	日   期： 2018-02-14 18:11:50
//Unity版本：5.6.4f1
//备     注：主角主城AI
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主角主城AI
/// </summary>
public class RoleMainPlayerCityAI : IRoleAI
{
    /// <summary>
    /// 当前角色控制器
    /// </summary>
    public RoleCtrl CurrRole { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="roleCtrl"></param>
    public RoleMainPlayerCityAI(RoleCtrl roleCtrl)
    {
        CurrRole = roleCtrl;
    }

    public void DoAI()
    {
        //执行AI

        //1.如果我有锁定敌人 就进行攻击
        if (CurrRole.LockEnemy != null)
        {
            if (CurrRole.LockEnemy.CurrRoleInfo.CurrHP <= 0)
            {
                CurrRole.LockEnemy = null;
                return;
            }

            if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum != RoleState.Attack)
            {
                CurrRole.ToAttack();
            }
        }
    }
}
