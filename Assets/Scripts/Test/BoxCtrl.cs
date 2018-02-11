using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCtrl : MonoBehaviour
{
    /// <summary>
    /// 移动的目标位置
    /// </summary>
    private Vector3 m_TargetPos = Vector3.zero;

    [SerializeField]
    private float m_Speed = 10f;

    void Start()
    {

    }

    void Update()
    {
        //点击屏幕
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("点击到屏幕了");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.gameObject.name.Equals("Ground", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    m_TargetPos = hitInfo.point;
                }
            }
        }

        //如果目标不是远点 进行移动
        if(m_TargetPos != Vector3.zero)
        {
            if (Vector3.Distance(m_TargetPos,transform.position)>0.1f)
            {
                transform.LookAt(m_TargetPos);
                transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);
            }

        }
    }
}
