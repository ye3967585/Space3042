using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//子弹发射器
public class ShootSystem : MonoBehaviour
{
    public float speed = 3;
    Rigidbody2D rigidbody2D;
    Transform transform2D;
    void Start()
    {
        transform2D = GetComponent<Transform>();
    }
    void Update()
    {
        transform2D.Translate(Vector2.up * speed * Time.deltaTime);
        //Destroy(gameObject, 2F);
    }
}
