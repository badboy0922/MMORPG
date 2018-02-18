//======================================================
//作     者：Ning	日   期： 2018-02-18 01:54:33
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleHeadBarCtrl : MonoBehaviour 
{
    /// <summary>
    /// 昵称
    /// </summary>
    [SerializeField]
    private UILabel lblNickName;

    /// <summary>
    /// 飘血显示
    /// </summary>
    [SerializeField]
    private HUDText hudText;

    /// <summary>
    /// 对齐的目标点
    /// </summary>
    private Transform m_Target;

	void Awake () 
	{
		
	}
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
        if (Camera.main == null || UICamera.mainCamera == null) return;
        //世界坐标点转换为视口坐标点
        Vector3 pos = Camera.main.WorldToViewportPoint(m_Target.position);

        //转换成UI摄像机的世界坐标
        Vector3 uiPos = UICamera.mainCamera.ViewportToWorldPoint(pos);

        gameObject.transform.position = uiPos;
	}

    public void Init(Transform target,string nickName)
    {
        m_Target = target;
        lblNickName.text = nickName;
    }

    /// <summary>
    /// 上弹伤害文字
    /// </summary>
    /// <param name="hurtValue"></param>
    public void SetHUDText(int hurtValue)
    {
        hudText.Add(string.Format("-{0}", hurtValue), Color.red, 0.1f);
    }
}
