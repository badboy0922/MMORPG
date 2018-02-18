//======================================================
//作     者：Ning	日   期： 2018-02-08 02:24:44
//Unity版本：5.6.4f1
//备     注：注册窗口UI控制器
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 注册窗口UI控制器
/// </summary>
public class UIRegCtrl : UIWindowBase
{
    /// <summary>
    /// 昵称
    /// </summary>
    [SerializeField]
    private UIInput m_InputNickName;

    /// <summary>
    /// 密码
    /// </summary>
    [SerializeField]
    private UIInput m_InputPwd;

    /// <summary>
    /// 确认密码
    /// </summary>
    [SerializeField]
    private UIInput m_InputPwd2;

    /// <summary>
    /// 提示
    /// </summary>
    [SerializeField]
    private UILabel m_LblTip;

    #region OnBtnClick 重写基类OnBtnClick
    /// <summary>
    /// 重写基类OnBtnClick
    /// </summary>
    /// <param name="go"></param>
    protected override void OnBtnClick(GameObject go)
    {
        switch (go.name)
        {
            case "btnToLogOn":
                BtnToLogOn();
                break;
            case "btnReg":
                Reg();
                break;
            default:
                break;
        }
    }
    #endregion

    /// <summary>
    /// 去登陆窗口
    /// </summary>
    private void BtnToLogOn()
    {
        this.Close();
        NextOpenWindow = WindowUIType.LogOn;
     }

    private void Reg()
    {
        string nickName = m_InputNickName.value.Trim();
        string pwd = m_InputPwd.value.Trim();
        string pwd2 = m_InputPwd2.value.Trim();

        if (string.IsNullOrEmpty(nickName))
        {
            m_LblTip.text = "请输入昵称";
            return;
        }

        if (string.IsNullOrEmpty(pwd))
        {
            m_LblTip.text = "请输入密码";
            return;
        }

        if (string.IsNullOrEmpty(pwd2))
        {
            m_LblTip.text = "请输入确认昵称";
            return;
        }

        if (pwd != pwd2)
        {
            m_LblTip.text = "两次输入密码不一致";
            return; 
        }

        PlayerPrefs.SetString(GlobalInit.MMO_NICKNAME, nickName);
        PlayerPrefs.SetString(GlobalInit.MMO_PWD, pwd);

        GlobalInit.Instance.CurrRoleNickName = nickName;

        SceneMgr.Instance.LoadToCity();
    }
}
