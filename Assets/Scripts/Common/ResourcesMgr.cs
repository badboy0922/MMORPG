using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ResourcesMgr : Singleton<ResourcesMgr>
{
    #region ResourceType 资源类型
    /// <summary>
    /// 资源类型
    /// </summary>
    public enum ResourceType
    {
        /// <summary>
        /// 场景UI
        /// </summary>
        UIScene,
        /// <summary>
        /// 窗口
        /// </summary>
        UIWindow,
        /// <summary>
        /// 角色
        /// </summary>
        Role,
        /// <summary>
        /// 特效
        /// </summary>
        Effect
    }
    #endregion

    private Hashtable m_PrefabTable;

    public ResourcesMgr()
    {
        m_PrefabTable = new Hashtable();
    }

    #region Load 加载资源

    /// <summary>
    /// 加载自预案
    /// </summary>
    /// <returns>The load.预设克隆体</returns>
    /// <param name="type">Type.资源类型</param>
    /// <param name="path">Path.短路径</param>
    /// <param name="cache">If set to <c>true</c> cache.是否放入缓存</param>
    public GameObject Load(ResourceType type, string path, bool cache = false)
    {

        GameObject obj = null;
        if (m_PrefabTable.Contains(path))
        {
            obj = m_PrefabTable[path] as GameObject;
        }
        else
        {
            StringBuilder sbr = new StringBuilder();
            switch (type)
            {
                case ResourceType.UIScene:
                    sbr.Append("UIPrefab/UIScene/");
                    break;
                case ResourceType.UIWindow:
                    sbr.Append("UIPrefab/UIWindows/");
                    break;
                case ResourceType.Role:
                    sbr.Append("RolePrefab/");
                    break;
                case ResourceType.Effect:
                    sbr.Append("EffectPrefab/");
                    break;
                default:
                    break;
            }
            sbr.Append(path);
            obj = Resources.Load(sbr.ToString()) as GameObject;
            if (cache)
            {
                m_PrefabTable.Add(path, obj);
            }
        }
        return GameObject.Instantiate(obj);
    }
    #endregion

    #region Dispose 释放资源
    /// <summary>
    /// 释放资源
    /// </summary>
    /// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:ResourcesMgr"/>. The
    /// <see cref="Dispose"/> method leaves the <see cref="T:ResourcesMgr"/> in an unusable state. After calling
    /// <see cref="Dispose"/>, you must release all references to the <see cref="T:ResourcesMgr"/> so the garbage
    /// collector can reclaim the memory that the <see cref="T:ResourcesMgr"/> was occupying.</remarks>
    public override void Dispose()
    {
        base.Dispose();
        m_PrefabTable.Clear();

        //把未使用的资源进行释放
        Resources.UnloadUnusedAssets();
    }
    #endregion


}
