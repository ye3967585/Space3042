using System.Collections.Generic;
using UnityEngine;


public class HpBox : MonoBehaviour {
    GameController gameController;
    public int AddValue;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "玩家")
        {
            gameController.CrtlHeath("add", AddValue);
            Destroy(gameObject);
        } 
    }
}
