using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��Ʒʵ��
/// </summary>
public partial class ProductEntity : AbstractEntity
{
    /// <summary>
    /// ��Ʒ����
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// �۸�
    /// </summary>
    public float Price { get; set; }

    /// <summary>
    /// ��ƷͼƬ����
    /// </summary>
    public string PicName { get; set; }

    /// <summary>
    /// ����
    /// </summary>
    public string Desc { get; set; }
}
