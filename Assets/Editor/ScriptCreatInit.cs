//========================================
// 备   注 : 替换代码注释
//========================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;

public class ScriptCreatInit : UnityEditor.AssetModificationProcessor
{
    //private static void OnWellCreateAsset(string path)
    //{
    //    path = path.Replace(".meta", "");
    //    if (path.EndsWith(".cs"))
    //    {
    //        string strContent = File.ReadAllText(path);
    //        strContent = strContent.Replace("#AuthourName#", "Ning").Replace("#CreateTime#", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    //        File.WriteAllText(path, strContent);
    //        AssetDatabase.Refresh();
    //    }
    //}
    public static void OnWillCreateAsset(string newFileMeta)
    {
        string newFilePath = newFileMeta.Replace(".meta", "");
        string fileExt = Path.GetExtension(newFilePath);
        if (fileExt != ".cs")
        {
            return;
        }
        //注意，Application.datapath会根据使用平台不同而不同
        string realPath = Application.dataPath.Replace("Assets", "") + newFilePath;
        string scriptContent = File.ReadAllText(realPath);

        //这里实现自定义的一些规则
        scriptContent = scriptContent.Replace("#COMPANY#", "Ning");
        scriptContent = scriptContent.Replace("#UNITYVERSION#", Application.unityVersion.ToString());
        scriptContent = scriptContent.Replace("#DATE#", System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        File.WriteAllText(realPath, scriptContent);
    }
}
