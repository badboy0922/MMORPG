//======================================================
//作     者：Ning	日   期： 2018-02-12 04:52:01
//Unity版本：5.6.4f1
//备     注：主城UI控制器
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主城UI控制器
/// </summary>
public class UISceneCityCtrl : UISceneBase
{
    protected override void OnBtnClick(GameObject go)
    {
        switch (go.gameObject.name)
        {
            case "btnHead":
                OpenRoleInfo();
                break;
            default:
                break;
        }
    }

    private void OpenRoleInfo()
    {
        WindowUIMgr.Instance.OpenWindow(WindowUIType.RoleInfo);
    }
}
