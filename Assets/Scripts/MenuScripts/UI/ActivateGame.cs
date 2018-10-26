using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateGame : Button_3D
{

    public GameObject gameBoardBig, gameBoardSmall;
    public GameObject StartGame;
    public GameObject panelToEnable;
    public GameObject panelToDisable;
    public ChangePlayBoardSize c_p_b;

    public MusicController mController;
    public GameObject musicControllerObject;

    void Start()
    {
        buttonPressed.AddListener(OnStart);
        musicControllerObject = GameObject.FindGameObjectWithTag("MusicController");
        mController = musicControllerObject.GetComponent<MusicController>();
        //gameBoardBig = SearchTransform(transform, "SpinFrameGroot", true).gameObject;
       // gameBoardSmall = GameObject.Find("SpinFrameKlein").transform.Find("SpawnerSmall").gameObject;
      //  gameBoardBig = GameObject.Find("SpinFrameGroot").transform.Find("SpawnerBig").gameObject;
    }

    void FixedUpdate()
    {
       // gameBoardSmall = GameObject.Find("SpinFrameKlein").transform.Find("SpawnerSmall").gameObject;
      //  gameBoardBig = GameObject.Find("SpinFrameGroot").transform.Find("SpawnerBig").gameObject;
    }

    void OnStart()
    {
        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
        if (c_p_b.isBoardSmall == true)
        {
            Debug.Log("ded");
            gameBoardSmall.SetActive(true);
        }
        else
        {
            Debug.Log("frfr");
            gameBoardBig.SetActive(true);
        }
        if (panelToEnable.gameObject == StartGame)
        {
            Debug.Log("cahngeaudio");
            mController.GameStarted();

        }
    }
}
