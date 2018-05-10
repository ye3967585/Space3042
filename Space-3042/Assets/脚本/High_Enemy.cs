using System.Collections;
using UnityEngine;


/// <summary>
/// 高阶敌人控制器
/// </summary>
public class High_Enemy : MonoBehaviour
{
   
    Transform _transform;
    Random random = new Random();
    int rangeNum;
    /// <summary>
    /// 刷新率
    /// </summary>
    public int RefreshRate;                                 //刷新率
    public GameObject ammo;                                 //要发射出去的子弹对象
    public Transform gun_1;                                 //枪械1
    public Transform gun_2;                                 //枪械2
    public Transform gun_3;                                 //枪械3
    public float ShootDelyms;                               //射击间隔
    public GameObject DropObject_1;                         //掉落物1
    public GameObject DropObject_2;                         //掉落物2
    public GameObject DropObject_3;                         //掉落物3
    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private void Update()
    {

    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(ammo, gun_1.position, gun_1.rotation);
            Instantiate(ammo, gun_2.position, gun_2.rotation);
            Instantiate(ammo, gun_3.position, gun_3.rotation);
            yield return new WaitForSeconds(ShootDelyms);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "子弹")
        {
            rangeNum = Random.Range(1, RefreshRate);
            if (rangeNum == RefreshRate - 1)
            {
                Instantiate(DropObject_1, _transform.position, _transform.rotation);
            }
            else if(rangeNum == RefreshRate - 2)
            {
                Instantiate(DropObject_2, _transform.position, _transform.rotation);
            }
            else if (rangeNum == RefreshRate - 3)
            {
                Instantiate(DropObject_3, _transform.position, _transform.rotation);
            }
        }

    }
}
