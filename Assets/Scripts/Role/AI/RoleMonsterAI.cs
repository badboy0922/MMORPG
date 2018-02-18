//======================================================
//作     者：Ning	日   期： 2018-02-14 18:14:16
//Unity版本：5.6.4f1
//备     注：怪AI
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 怪AI
/// </summary>
public class RoleMonsterAI : IRoleAI
{
    /// <summary>
    /// 当前角色控制器
    /// </summary>
    public RoleCtrl CurrRole { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="roleCtrl"></param>
    public RoleMonsterAI(RoleCtrl roleCtrl)
    {
        CurrRole = roleCtrl;
    }

    public void DoAI()
    {
        //执行AI
    }
}
