//======================================================
//作     者：Ning	日   期： 2018-02-10 19:46:33
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInit : MonoBehaviour
{
    #region 常量
    /// <summary>
    /// 昵称KEY
    /// </summary>
    public const string MMO_NICKNAME = "MMO_NICKNAME";

    /// <summary>
    /// 密码KEY
    /// </summary>
    public const string MMO_PWD = "MMO_PWD";

    #endregion

    public static GlobalInit Instance;

    /// <summary>
    /// UI动画曲线
    /// </summary>
    public AnimationCurve UIAnimationCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

}
