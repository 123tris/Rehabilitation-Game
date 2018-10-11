using UnityEngine;
using System.Collections;

public class SwitchPanel : Button_3D
{

    public GameObject panelToEnable;
    public GameObject panelToDisable;

    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }

    void OnStart()
    {
        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
    }

    public void Switch()
    {
        panelToDisable.SetActive(false);
        panelToEnable.SetActive(true);
    }

}
