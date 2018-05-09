using UnityEngine;

/// <summary>
/// 摧毁玩家或敌人
/// </summary>
public class DestoryObject : MonoBehaviour
{
    public GameObject PlayerBoom, EnemyBoom;
    GameController gameController;
    public int KillScore;
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("gameControllerObject=null!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //被玩家射中
        if (other.tag == "子弹")
        {
            //Debug.Log("子弹");
            gameController.AddScore(KillScore);
            Instantiate(EnemyBoom, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        //自杀式两方相撞
        if (other.tag == "玩家")
        {
            Instantiate(PlayerBoom, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameController.Live(true);  //死亡
        }
    }
}
