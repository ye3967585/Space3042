using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 销毁自己
/// </summary>
public class DestoryThis : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.3f);
    }


}
