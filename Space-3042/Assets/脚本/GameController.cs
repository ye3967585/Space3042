using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text UI_ScorePanel;
    public Text UI_GameOver;
    private int score;
    [HideInInspector]
    public bool isOver;
    public float ReadyTime;                 //准备时间
    public GameObject Enemy;                //生成物
    public int EnemySpawnCount;             //刷敌次数
    public float EnemySpawnDleyms;          //刷敌间隔
    public Vector2 SpawnValues;             //生成点


    /// <summary>
    /// 敌人生成器
    /// </summary>
    IEnumerator SpawnEnemy()
    {
        //Enemy.transform.Rotate(new Vector3(1f, -2f, -180f));
        yield return new WaitForSeconds(ReadyTime);
        while (true)
        {
            for (int i = 0; i < EnemySpawnCount; i++)
            {
                Vector2 SpawnPos = new Vector2(Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y);
                Instantiate(Enemy, SpawnPos, Enemy.transform.rotation);
                yield return new WaitForSeconds(EnemySpawnDleyms);
            }

        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        UI_GameOver.text = "\t";
        UpdateScore();
        if (Enemy == null)
        {
            Enemy = (GameObject)Resources.Load("预制件/敌人_高阶");
        }
    }

    /// <summary>
    /// 增加分数
    /// </summary>
    /// <param name="valueScore">要增加的分数</param>
    public void AddScore(int valueScore)
    {
        score += valueScore;
        UpdateScore();
    }
    /// <summary>
    /// 更新分数信息
    /// </summary>
    void UpdateScore()
    {
        UI_ScorePanel.text = "SCORE : " + score.ToString("D5");
    }
    /// <summary>
    /// 判断是否死亡
    /// </summary>
    /// <param name="state"></param>
    public void Live(bool state)
    {
        isOver = state;
        if (isOver)
        {
            Debug.Log("你他妈死了");
            Time.timeScale = 0;
            UI_GameOver.text = "GAME OVER";
        }
    }
}
