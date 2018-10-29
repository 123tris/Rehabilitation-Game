using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : Button_3D {

    public GameObject spawnSmall, spawnBig;
    public GameObject panelToEnable;
    public GameObject panelToDisable;
    public ChangePlayBoardSize c_p_b;

    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }

    void OnStart()
    {
        spawnSmall = GameObject.FindGameObjectWithTag("SpawnerKlein");
        spawnBig = GameObject.FindGameObjectWithTag("SpawnerBig");
        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
        if (c_p_b.isBoardSmall == true)
        {
            foreach (Transform child in spawnSmall.transform)
            {
                child.gameObject.SetActive(true);
            }
            spawnSmall.GetComponent<Bumper_placer>().enabled = true;
        }
        else
        {
            foreach (Transform child in spawnBig.transform)
            {
                child.gameObject.SetActive(true);
            }
            spawnBig.GetComponent<Bumper_placer>().enabled = true;
        }
    }
}
