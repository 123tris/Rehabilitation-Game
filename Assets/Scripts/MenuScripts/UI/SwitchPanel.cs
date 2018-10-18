using UnityEngine;
using System.Collections;

public class SwitchPanel : Button_3D
{

    public GameObject panelToEnable;
    public GameObject panelToDisable;

    [FMODUnity.EventRef]
    public string ClickSound = "event:/Menu/Click";

    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }

    void OnStart()
    {
        FMODUnity.RuntimeManager.PlayOneShot(ClickSound, transform.position);
        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
    }

}
