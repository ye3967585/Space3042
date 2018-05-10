using UnityEngine;

public class Camera_AnimationControll : MonoBehaviour
{
    int NowHp;
    bool PLAY= false;
    Animator Dead;
    GameController gameController;
    private void Start()
    {
        //PLAY = false;
        Dead = GetComponent<Animator>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    private void Update()
    {
        NowHp = gameController.GetNowHp();
        if (NowHp == 0 || NowHp <= 0)
        {
            PLAY = true;
            Dead.SetBool("isOver", PLAY);
        }
    }

}
