using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敌人AI
/// </summary>
public class AI : MonoBehaviour {

    public Transform playTransform;     //玩家的方位
    Transform thisTransform;            //自己的方位
    public float speed;                 //移动速率
    private void Start()
    {
        thisTransform = GetComponent<Transform>();
    }
    private void Update()
    {
        thisTransform.Translate(new Vector2(playTransform.position.x-2f,playTransform.position.y - 2f) *speed*Time.deltaTime, Space.World);  
    }
    

}
