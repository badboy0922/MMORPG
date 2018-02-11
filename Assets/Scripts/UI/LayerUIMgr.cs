//======================================================
//作     者：Ning	日   期： 2018-02-11 00:44:16
//Unity版本：5.6.4f1
//备     注：UI层级管理器
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI层级管理器
/// </summary>
public class LayerUIMgr : Singleton<LayerUIMgr>
{
    /// <summary>
    /// UIPanel层级深度
    /// </summary>
    private int m_UIPanelDDepth = 50;

    /// <summary>
    /// 重置
    /// </summary>
    public void Reset()
    {
        m_UIPanelDDepth = 50;
    }

    /// <summary>
    /// 检查窗口数量，如果没有打开的窗口，重置
    /// </summary>
    public void CheckOpenWindow()
    {
        if(WindowUIMgr.Instance.OpenWindowCount == 0)
        {
            Reset();
        }
    }

    /// <summary>
    /// 设置层级
    /// </summary>
    /// <param name="obj"></param>
    public void SetLayer(GameObject obj)
    {
        m_UIPanelDDepth += 1;
        UIPanel[] panArr = obj.GetComponentsInChildren<UIPanel>();
        if (panArr.Length > 0)
        {
            for (int i = 0; i < panArr.Length; i++)
            {
                panArr[i].depth += m_UIPanelDDepth;
            }
        }
    }
}
