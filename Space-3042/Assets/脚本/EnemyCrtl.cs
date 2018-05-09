using System.Collections;
using UnityEngine;

/// <summary>
/// 敌人控制器
/// </summary>
public class EnemyCrtl : MonoBehaviour
{
    public GameObject ammo;                                 //要发射出去的子弹对象
    public Transform gun_1;                                 //枪械1
    public Transform gun_2;                                 //枪械2
    public Transform gun_3;                                 //枪械3
    public float ShootDelyms;                               //射击间隔
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
}
