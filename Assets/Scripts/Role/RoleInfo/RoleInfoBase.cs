//======================================================
//作     者：Ning	日   期： 2018-02-14 18:12:37
//Unity版本：5.6.4f1
//备     注：角色信息基类
//======================================================

/// <summary>
/// 角色信息基类
/// </summary>
public class RoleInfoBase
{
    /// <summary>
    /// 角色服务器编号 
    /// </summary>
    public int RoleServerID;

    /// <summary>
    /// 角色编号
    /// </summary>
    public int RoleID;

    /// <summary>
    /// 昵称
    /// </summary>
    public string NickName;

    /// <summary>
    /// 最大血量
    /// </summary>
    public int MaxHP;

    /// <summary>
    /// 当前血量
    /// </summary>
    public int CurrHP;
}
