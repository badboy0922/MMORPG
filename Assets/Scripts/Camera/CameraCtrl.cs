using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public static CameraCtrl Instance;

    /// <summary>
    /// 控制摄像机上下
    /// </summary>
    [SerializeField]
    private Transform m_CamereUpAndDown;

    /// <summary>
    /// 控制摄像机缩放父物体
    /// </summary>
    [SerializeField]
    private Transform m_CameraZoomContainer;

    /// <summary>
    /// 摄像机容器
    /// </summary>
    [SerializeField]
    private Transform m_CameraContainer;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        m_CamereUpAndDown.localEulerAngles = new Vector3(0, 0, Mathf.Clamp(m_CamereUpAndDown.localEulerAngles.z, 35f, 80f));

    }
    /// <summary>
    /// 设置摄像机旋转
    /// </summary>
    /// <param name="type">0=左 1=右</param>
    public void SetCameraRotate(int type)
    {
        transform.Rotate(0, 40 * Time.deltaTime * (type == 0 ? -1 : 1), 0);
    }

    /// <summary>
    /// 设置摄像机上下
    /// </summary>
    /// <param name="type">0=上 1=下</param>
    public void SetCameraUpAndDown(int type)
    {
        m_CamereUpAndDown.transform.Rotate(0, 0, 30 * Time.deltaTime * (type == 1 ? -1 : 1));
        m_CamereUpAndDown.localEulerAngles = new Vector3(0, 0, Mathf.Clamp(m_CamereUpAndDown.localEulerAngles.z, 35f, 80f));
    }

    /// <summary>
    /// 设置摄像机缩放
    /// </summary>
    /// <param name="type">0=拉近 1=拉远</param>
    public void SetCameraZoom(int type)
    {
        m_CameraContainer.Translate(Vector3.forward * 10 * Time.deltaTime * (type == 1 ? -1 : 1));
        m_CameraContainer.localPosition = new Vector3(0, 0, Mathf.Clamp(m_CameraContainer.localPosition.z, -5f, 5f));
    }

    /// <summary>
    /// 摄像机实时看着主角
    /// </summary>
    /// <param name="pos"></param>
    public void AutoLookAt(Vector3 pos)
    {
        m_CameraZoomContainer.LookAt(pos);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 15f);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 14f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 12f);
    }
}
