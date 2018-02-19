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
    /// 下次巡逻时间
    /// </summary>
    private float m_NextPatrolTime = 0;

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
        //如果是待机状态
        if (CurrRole.CurrRoleFSMMgr.CurrRoleStateEnum == RoleState.Idle)
        {
            if (Time.time > m_NextPatrolTime)
            {
                m_NextPatrolTime = Time.time + Random.Range(5f, 10f);
                //进行巡逻
                CurrRole.MoveTo(new Vector3(CurrRole.BornPoint.x + UnityEngine.Random.Range(CurrRole.PatrolRange * -1, CurrRole.PatrolRange), CurrRole.BornPoint.y, CurrRole.BornPoint.z + UnityEngine.Random.Range(CurrRole.PatrolRange * -1, CurrRole.PatrolRange)));
            }
        }

    }
}
