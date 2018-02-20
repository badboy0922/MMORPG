//======================================================
//作     者：Ning	日   期： 2018-02-21 03:35:22
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerInfo : MonoBehaviour
{
    /// <summary>
    /// 昵称
    /// </summary>
    [SerializeField]
    private UILabel lblNickName;

    /// <summary>
    /// 昵称
    /// </summary>
    [SerializeField]
    private UISprite sprHP;

    public static UIPlayerInfo Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (GlobalInit.Instance.CurrPlayer != null)
        {
            GlobalInit.Instance.CurrPlayer.OnRoleHurt = MainPlayerHurt;
        }
    }

    private void MainPlayerHurt()
    {
        sprHP.fillAmount = (float)GlobalInit.Instance.CurrPlayer.CurrRoleInfo.CurrHP / GlobalInit.Instance.CurrPlayer.CurrRoleInfo.MaxHP;
    }

    public void SetPlayerInfo()
    {
        lblNickName.text = GlobalInit.Instance.CurrPlayer.CurrRoleInfo.NickName;
    }
}
