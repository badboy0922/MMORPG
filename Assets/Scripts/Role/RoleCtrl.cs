using UnityEngine;

/// <summary>
/// 角色控制器
/// </summary>
public class RoleCtrl : MonoBehaviour
{

    #region 成员变量或属性
    /// <summary>
    /// 动画
    /// </summary>
    [SerializeField]
    public Animator Animator;

    /// <summary>
    /// 移动的目标位置
    /// </summary>
    private Vector3 m_TargetPos = Vector3.zero;

    private CharacterController m_CharacterController;

    [SerializeField]
    private float m_Speed = 10f;

    /// <summary>
    /// 转身的速度
    /// </summary>
    private float m_RotationSpeed = 0.2f;

    /// <summary>
    /// 转身的方向
    /// </summary>
    private Quaternion m_TargetQuaternion;

    /// <summary>
    /// 当前角色类型
    /// </summary>
    public RoleType CurrRoleType = RoleType.None;

    /// <summary>
    /// 当前角色信息
    /// </summary>
    public RoleInfoBase CurrRoleInfo = null;

    /// <summary>
    /// 当前角色AI
    /// </summary>
    public IRoleAI CurrRoleAI = null;

     /// <summary>
     /// 当前角色有限状态机管理器
     /// </summary>
    public RoleFSMMgr CurrRoleFSMMgr = null;
    #endregion

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="roleType">角色类型</param>
    /// <param name="roleInfo">角色信息</param>
    /// <param name="ai">角色AI</param>
    public void Init(RoleType roleType, RoleInfoBase roleInfo,IRoleAI ai)
    {
        CurrRoleType = roleType;
        CurrRoleInfo = roleInfo;
        CurrRoleAI = ai;
    }

    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();

        if (CameraCtrl.Instance != null)
        {
            CameraCtrl.Instance.Init();
        }
        if (FingerEvent.Instance != null)
        {
            FingerEvent.Instance.OnFingerDrag += OnFingerDrag;
            FingerEvent.Instance.OnZoom += OnZoom;
            FingerEvent.Instance.OnPlayerClickGround += OnPlayerClickGround;
        }
        CurrRoleFSMMgr = new RoleFSMMgr(this);
    }

    void Update()
    {
        //角色必须有AI
        if (CurrRoleAI == null) return;
        CurrRoleAI.DoAI();

        if (CurrRoleFSMMgr != null)
            CurrRoleFSMMgr.OnUpdate();

        if (m_CharacterController == null) return;

        //让角色贴着地面
        if (!m_CharacterController.isGrounded)
        {
            m_CharacterController.Move((transform.position + new Vector3(0, -1000, 0)) - transform.position);
        }

        //AnimatorStateInfo info = m_Animator.GetCurrentAnimatorStateInfo(0);
        //if (info.IsName("Idle_Normal"))
        //{
        //    m_Animator.SetInteger("CurrState", 1);
        //}
        //else if (info.IsName("Idle_Fight"))
        //{
        //    m_Animator.SetInteger("CurrState", 2);
        //}
        //else if (info.IsName("Run"))
        //{
        //    m_Animator.SetInteger("CurrState", 3);
        //}
        //else if (info.IsName("Hurt"))
        //{
        //    m_Animator.SetInteger("CurrState", 4);
        //}
        //else if (info.IsName("Die"))
        //{
        //    m_Animator.SetInteger("CurrState", 5);
        //}
        //else if (info.IsName("PhyAttack1"))
        //{
        //    m_Animator.SetInteger("CurrState", 6);

        //    if (info.normalizedTime > 1)
        //    {
        //        this.Reset();
        //        m_Animator.SetBool("ToIdleNormal", true);
        //    }
        //}

        //if (Input.GetKeyUp(KeyCode.R))
        //{
        //    this.Reset();
        //    m_Animator.SetBool("ToRun", true);
        //}
        //else if (Input.GetKeyUp(KeyCode.N))
        //{
        //    this.Reset();
        //    m_Animator.SetBool("ToIdleNormal", true);
        //}
        //else if (Input.GetKeyUp(KeyCode.A))
        //{
        //    this.Reset();
        //    m_Animator.SetInteger("ToPhyAttack", 1);
        //}

        //如果目标不是远点 进行移动
        if (m_TargetPos != Vector3.zero)
        {
            if (Vector3.Distance(m_TargetPos, transform.position) > 0.1f)
            {
                Vector3 direction = m_TargetPos - transform.position;
                direction = direction.normalized;//归一化
                direction = direction * Time.deltaTime * m_Speed;
                //transform.LookAt(new Vector3(m_TargetPos.x, transform.position.y, m_TargetPos.z));
                //让角色转身
                if (m_RotationSpeed <= 1)
                {
                    m_RotationSpeed += 5f * Time.deltaTime;
                    m_TargetQuaternion = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Lerp(transform.rotation, m_TargetQuaternion, m_RotationSpeed);
                }
                m_CharacterController.Move(direction);
            }
        }

        CameraAutoFllow();
    }

    #region OnZoom OnZoom
    /// <summary>
    /// 摄像机缩放
    /// </summary>
    /// <param name="obj"></param>
    private void OnZoom(FingerEvent.ZoomType obj)
    {
        switch (obj)
        {
            case FingerEvent.ZoomType.In:
                CameraCtrl.Instance.SetCameraZoom(0);
                break;
            case FingerEvent.ZoomType.Out:
                CameraCtrl.Instance.SetCameraZoom(1);
                break;
            default:
                break;
        }
    }
    #endregion

    #region OnPlayerClickGround 玩家点击地面
    /// <summary>
    /// 玩家点击地面
    /// </summary>
    private void OnPlayerClickGround()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.name.Equals("Ground", System.StringComparison.CurrentCultureIgnoreCase))
            {
                m_TargetPos = hitInfo.point;
                m_RotationSpeed = 0;
            }
        }
    }
    #endregion

    #region OnFingerDrag 手指滑动
    /// <summary>
    /// 手指滑动
    /// </summary>
    /// <param name="obj"></param>
    private void OnFingerDrag(FingerEvent.FingerDir obj)
    {
        switch (obj)
        {
            case FingerEvent.FingerDir.Left:
                CameraCtrl.Instance.SetCameraRotate(0);
                break;
            case FingerEvent.FingerDir.Right:
                CameraCtrl.Instance.SetCameraRotate(1);
                break;
            case FingerEvent.FingerDir.Up:
                CameraCtrl.Instance.SetCameraUpAndDown(1);
                break;
            case FingerEvent.FingerDir.Down:
                CameraCtrl.Instance.SetCameraUpAndDown(0);
                break;
            default:
                break;
        }
    }
    #endregion

    #region OnDestroy 销毁
    /// <summary>
    /// 销毁
    /// </summary>
    private void OnDestroy()
    {
        if (FingerEvent.Instance != null)
        {
            FingerEvent.Instance.OnFingerDrag -= OnFingerDrag;
            FingerEvent.Instance.OnZoom -= OnZoom;
            FingerEvent.Instance.OnPlayerClickGround -= OnPlayerClickGround;
        }
    }
    #endregion

    private void Reset()
    {
        Animator.SetBool("ToIdleNormal", false);
        Animator.SetBool("ToRun", false);
        Animator.SetBool("ToHurt", false);
        Animator.SetBool("ToDie", false);
        Animator.SetBool("ToIdleFight", false);
        Animator.SetInteger("ToPhyAttack", 0);

    }


    #region CameraAutoFllow 摄像机自动跟随
    /// <summary>
    /// 摄像机自动跟随
    /// </summary>
    private void CameraAutoFllow()
    {
        if (CameraCtrl.Instance == null) return;

        CameraCtrl.Instance.transform.position = gameObject.transform.position;
        CameraCtrl.Instance.AutoLookAt(gameObject.transform.position);

        //if (Input.GetKey(KeyCode.A))
        //{
        //    CameraCtrl.Instance.SetCameraRotate(0);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    CameraCtrl.Instance.SetCameraRotate(1);
        //}
        //else if (Input.GetKey(KeyCode.W))
        //{
        //    CameraCtrl.Instance.SetCameraUpAndDown(0);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    CameraCtrl.Instance.SetCameraUpAndDown(1);
        //}
        //else if (Input.GetKey(KeyCode.I))
        //{
        //    CameraCtrl.Instance.SetCameraZoom(0);
        //}
        //else if (Input.GetKey(KeyCode.L))
        //{
        //    CameraCtrl.Instance.SetCameraZoom(1 );
        //}
    }
    #endregion
}
