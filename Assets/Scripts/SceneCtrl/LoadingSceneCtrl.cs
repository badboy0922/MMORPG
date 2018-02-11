//======================================================
//作     者：Ning	日   期： 2018-02-11 23:05:45
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneCtrl : MonoBehaviour
{
    /// <summary>
    /// UI场景控制器
    /// </summary>
    [SerializeField]
    private UISceneLoadingCtrl m_UILoadingCtrl;


    private AsyncOperation m_Async = null;

    /// <summary>
    /// 当前的进度
    /// </summary>
    private int m_CurrProgress = 0;

    void Start()
    {
        LayerUIMgr.Instance.Reset();
        StartCoroutine(LoadingScene());
    }


    private IEnumerator LoadingScene()
    {
        string strSceneName = string.Empty;
        switch (SceneMgr.Instance.CurrentSceneType)
        {
            case SceneType.LogOn:
                strSceneName = "Scene_LogOn";
                break;
            case SceneType.City:
                strSceneName = "GameScene_CunZhuang";
                break;
            default:
                break;
        }
        m_Async = SceneManager.LoadSceneAsync(strSceneName);
        m_Async.allowSceneActivation = false;
        yield return m_Async;
    }

    void Update()
    {
        int toProgress = 0;
        if (m_Async.progress < 0.9f)
        {
            toProgress = Mathf.Clamp((int)m_Async.progress * 100, 1, 100);
        }
        else
        {
            toProgress = 100;
        }

        if (m_CurrProgress < toProgress)
        {
            m_CurrProgress++;
        }
        else
        {
            m_Async.allowSceneActivation = true;
        }
        m_UILoadingCtrl.SetProgressValue(m_CurrProgress * 0.01f);
    }
}
