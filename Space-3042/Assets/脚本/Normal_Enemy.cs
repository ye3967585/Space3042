using System.Collections;
using UnityEngine;

/// <summary>
/// 中级敌人
/// </summary>
public class Normal_Enemy : MonoBehaviour
{
    Transform _transform;
    Random random = new Random();
    int rangeNum;
    /// <summary>
    /// 刷新率
    /// </summary>
    public int RefreshRate;                                 //刷新率
    public GameObject ammo;                                 //要发射出去的子弹对象
    public GameObject DropObject_1;                         //掉落物1
    public GameObject DropObject_2;                         //掉落物2
    public Transform gun;                                   //枪械1
    public Transform gun_2;                                 //枪械2
    public float ShootDelyms;                               //射击间隔

    private void Start()
    {
        StartCoroutine(Shoot());
        _transform = GetComponent<Transform>();
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(ammo, gun.position, gun.rotation);
            Instantiate(ammo, gun_2.position, gun_2.rotation);
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
            else if (rangeNum == RefreshRate - 2)
            {
                Instantiate(DropObject_2, _transform.position, _transform.rotation);
            }
        }

    }
}
