using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : Singleton<SceneMgr>
{
    /// <summary>
    /// 当前场景类型
    /// </summary>
    public SceneType CurrentSceneType
    {
        get;
        private set;
    }
    public void LoadToLogOn()
    {
        CurrentSceneType = SceneType.LogOn;
        SceneManager.LoadScene("Scene_Loading");
    }
    /// <summary>
    /// 去城镇场景
    /// </summary>
    public void LoadToCity()
    {
        CurrentSceneType = SceneType.City;
        SceneManager.LoadScene("Scene_Loading");
    }
}
