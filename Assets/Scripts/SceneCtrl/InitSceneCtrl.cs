//======================================================
//作     者：Ning	日   期： 2018-02-12 02:59:24
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitSceneCtrl : MonoBehaviour 
{	
	void Start () 
	{
        StartCoroutine(LoadLogOn());
	}

    private IEnumerator LoadLogOn()
    {
        yield return new WaitForSeconds(2f);
        SceneMgr.Instance.LoadToLogOn();
    }
}
