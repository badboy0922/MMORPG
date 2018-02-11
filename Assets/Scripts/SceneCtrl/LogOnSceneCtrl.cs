using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogOnSceneCtrl : MonoBehaviour
{
    GameObject obj;
    void Awake()
    {
        SceneUIMgr.Instance.LoadSceneUI(SceneUIMgr.SceneUIType.LogOn);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
