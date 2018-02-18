//======================================================
//作     者：Ning	日   期： 2018-02-18 01:42:39
//Unity版本：5.6.4f1
//备     注：
//======================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleHeadBarRoot : MonoBehaviour 
{
    public static RoleHeadBarRoot Instance;

	void Awake () 
	{
        Instance = this;
    }
}
