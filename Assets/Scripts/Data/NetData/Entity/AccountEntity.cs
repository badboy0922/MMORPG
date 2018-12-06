using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ’Àªß µÃÂ
/// </summary>
public class AccountEntity : MonoBehaviour
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Pwd { get; set; }

    public int YuanBao { get; set; }

    public int LastServerId { get; set; }

    public string LastServerName { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }
}
