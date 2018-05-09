using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 边界设置
/// </summary>
[Serializable]
public class Wall
{
    public float xMin, xMax, yMin, yMax;
}

/// <summary>
/// 本脚本用于控制基本操作
/// </summary>
public class PlayerCrtl : MonoBehaviour
{
    public GameObject PlayerBoom;
    public float speed = 3;                                 //移动速度
    public Wall wall;                                       //边界
    public GameObject ammo;                                 //要发射出去的子弹对象
    public Transform gun;                                   //枪械的位置
    float moveH, moveV;                                     //水平移动(X)与垂直移动(Y)  
    Transform transform2D;                                  //坐标系  
    GameController gameController;
    void Start()
    {
        transform2D = GetComponent<Transform>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }
    void Update()
    {

        #region 玩家移动
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        transform2D.Translate(Vector3.right * moveH * speed * Time.deltaTime, Space.World);
        transform2D.Translate(Vector3.up * moveV * speed * Time.deltaTime, Space.World);
        //Debug.Log("X:" + moveH + " -Y:" + moveV);
        //限制移动范围
        transform2D.position = new Vector2(Mathf.Clamp(transform2D.position.x, wall.xMin, wall.xMax), Mathf.Clamp(transform2D.position.y, wall.yMin, wall.yMax));
        #endregion

        #region 射他妈的
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot(ammo, gun);
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "敌人子弹")
        {
            Instantiate(PlayerBoom, transform.position, transform.rotation);
            Destroy(gameObject);
            gameController.Live(true);
        }
    }

    #region 自定义方法集
    /// <summary>
    /// 发射子弹
    /// </summary>
    /// <param name="Ammo">子弹对象</param>
    /// <param name="Gun">枪械方位</param>
    void Shoot(GameObject Ammo, Transform Gun)
    {
        Instantiate(Ammo, Gun.position, Gun.rotation);
    }
    #endregion
}
