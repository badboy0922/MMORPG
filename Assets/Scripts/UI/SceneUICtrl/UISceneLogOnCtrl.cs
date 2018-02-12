//======================================================
//作     者：Ning	日   期： 2018-02-08 02:07:15
//Unity版本：5.6.4f1
//备     注：登陆场景UI控制器
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 登陆场景UI控制器
/// </summary>
public class UISceneLogOnCtrl : UISceneBase
{
    protected override void OnStart()
    {
        base.OnAwake();
        StartCoroutine(OpenLogOnWindow());
    }

    private IEnumerator OpenLogOnWindow()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject obj = WindowUIMgr.Instance.OpenWindow(WindowUIType.LogOn);
    }
}
