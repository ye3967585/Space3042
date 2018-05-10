using System.Collections;
using UnityEngine;

/// <summary>
/// 低级敌人控制器
/// </summary>
public class Enemy : MonoBehaviour
{
    Transform _transform;
    int rangeNum;
    /// <summary>
    /// 刷新率
    /// </summary>
    public int RefreshRate;                                 //刷新率
    int _ran;
    public GameObject ammo;                                 //要发射出去的子弹对象
    public GameObject[] DropObject;                         //掉落物
    public Transform gun;                                   //枪械
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
            yield return new WaitForSeconds(ShootDelyms);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "子弹")
        {
            _ran = Random.Range(0, 20);
            if (_ran == RefreshRate)
            {
                rangeNum = Random.Range(0, DropObject.Length);
                Instantiate(DropObject[rangeNum], _transform.position, _transform.rotation);
            }
        }
       
    }
}
