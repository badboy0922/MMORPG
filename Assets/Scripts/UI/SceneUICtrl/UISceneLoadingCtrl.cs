//======================================================
//作     者：Ning	日   期： 2018-02-11 03:09:11
//Unity版本：5.6.4f1
//备     注：Loading场景UI控制器
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Loading场景UI控制器
/// </summary>
public class UISceneLoadingCtrl : UISceneBase
{
    /// <summary>
    /// 进度条
    /// </summary>
    [SerializeField]
    private UIProgressBar m_Progress;

    /// <summary>
    /// 进度条上的文本
    /// </summary>
    [SerializeField]
    private UILabel m_LblProgress;

    /// <summary>
    /// 发光的图
    /// </summary>
    [SerializeField]
    private UISprite m_SprProgressLight;

    /// <summary>
    /// 设置进度条的值
    /// </summary>
    /// <param name="value"></param>
    public void SetProgressValue(float value)
    {
        m_Progress.value = value;
        m_LblProgress.text = string.Format("{0}%", (int)(value * 100));
        m_SprProgressLight.transform.localPosition = new Vector3(1125f * value, 0, 0);
    }
}
