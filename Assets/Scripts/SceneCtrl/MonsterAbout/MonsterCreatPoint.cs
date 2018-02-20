//======================================================
//作     者：Ning	日   期： 2018-02-18 23:45:35
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreatPoint : MonoBehaviour
{
    /// <summary>
    /// 最大刷怪数量
    /// </summary>
    [SerializeField]
    private int m_MaxCount;

    /// <summary>
    /// 怪名称
    /// </summary>
    [SerializeField]
    private string monsterName;

    /// <summary>
    /// 当前数量
    /// </summary>
    private int m_CurrCount;

    private float m_PrevCreatTime;

    void Start()
    {

    }

    void Update()
    {
        if (m_CurrCount < m_MaxCount)
        {
            if (Time.time > m_PrevCreatTime + UnityEngine.Random.Range(1.5f, 3.5f))
            {
                m_PrevCreatTime = Time.time;

                //创建怪
                GameObject objClone = RoleMgr.Instance.LoadRole(monsterName, RoleType.Monster);

                objClone.transform.parent = transform;
                objClone.transform.position = transform.TransformPoint(new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), 0, UnityEngine.Random.Range(-0.5f, 0.5f)));
                RoleCtrl roleCtrl = objClone.GetComponent<RoleCtrl>();
                roleCtrl.BornPoint = objClone.transform.position;

                RoleInfoMonster roleInfo = new RoleInfoMonster();
                roleInfo.RoleServerID = DateTime.Now.Ticks;
                roleInfo.RoleID = 1;
                roleInfo.CurrHP = roleInfo.MaxHP = 1000;
                roleInfo.NickName = "偷书盗贼";

                roleCtrl.Init(RoleType.Monster, roleInfo, new RoleMonsterAI(roleCtrl));

                m_CurrCount++;
            }
        }
    }
}
