//======================================================
//作     者：Ning	日   期： 2018-02-09 03:32:25
//Unity版本：5.6.4f1
//备     注：所有UI的基类
//======================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 所有UI的基类
/// </summary>
public class UIBase : MonoBehaviour
{

    private void Awake()
    {
        OnAwake();
    }

    void Start()
    {
        UIButton[] btnArr = GetComponentsInChildren<UIButton>(true);
        for (int i = 0; i < btnArr.Length; i++)
        {
            UIEventListener.Get(btnArr[i].gameObject).onClick = BtnClick;
        }

        OnStart();
    }

    private void OnDestroy()
    {
        BeforeOnDestroy();
    }

    private void BtnClick(GameObject go)
    {
        OnBtnClick(go);
    }

    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void BeforeOnDestroy() { }
    protected virtual void OnBtnClick(GameObject go) { }
}
