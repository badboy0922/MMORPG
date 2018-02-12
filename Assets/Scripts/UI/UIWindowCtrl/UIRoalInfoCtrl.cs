//======================================================
//作     者：Ning	日   期： 2018-02-12 05:34:02
//Unity版本：5.6.4f1
//备     注：角色信息窗口控制器
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色信息窗口控制器
/// </summary>
public class UIRoalInfoCtrl : UIWindowBase
{
    protected override void OnBtnClick(GameObject go)
    {
        switch (go.gameObject.name)
        {
            case "btnClose":
                Close();
                break;

            default:
                break;
        }
    }
}
