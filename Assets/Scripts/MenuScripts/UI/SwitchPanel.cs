using UnityEngine;

public class SwitchPanel : Button_3D
{
    public GameObject panelToEnable;
    public GameObject panelToDisable;

    [FMODUnity.EventRef]
    public string ClickSound = "event:/Menu/Click";

    [FMODUnity.EventRef]
    public string BoardSwitchSound = "event:/Menu/Switch";

    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }

    void OnStart()
    {
        FMODUnity.RuntimeManager.PlayOneShot(ClickSound, transform.position);

        FMODUnity.RuntimeManager.PlayOneShot(BoardSwitchSound, transform.position);
        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
    }

}
