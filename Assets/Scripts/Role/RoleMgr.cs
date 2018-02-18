//======================================================
//作     者：Ning	日   期： 2018-02-17 05:19:37
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleMgr : Singleton<RoleMgr>
{
    #region LoadRole 根据角色预设名称 加载角色
    /// <summary>
    /// 根据角色预设名称 克隆角色
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject LoadRole(string name, RoleType type)
    {
        string path = string.Empty;
        switch (type)
        {
            case RoleType.MainPlayer:
                path = "Player";
                break;
            case RoleType.Monster:
                path = "Monster";
                break;
            default:
                break;
        }
        return ResourcesMgr.Instance.Load(ResourcesMgr.ResourceType.Role, string.Format("{0}/{1}", path, name), cache: true);
    }
    #endregion


    public override void Dispose()
    {
        base.Dispose();
    }
}
