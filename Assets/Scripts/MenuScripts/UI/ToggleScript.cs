using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour {


    Text toggleText;
    public bool isToggleOn;
    public GameObject panelToEnable;
    public GameObject panelToDisable;
    public ToggleBool toggleBool;
    public bool isLast;

    [FMODUnity.EventRef]
    public string CheckSound = "event:/Menu/Check";

    void Update()
    {
        if (toggleBool.isClicked == true)
        {
            SelectAccount();
        }
    }

    public void AccountToggle(bool toggle)
    {
        if (toggle == true)
        {
            isToggleOn = true;
        }
        else
        {
            isToggleOn = false;
        }
    }

    void SelectAccount()
    {
        if (isToggleOn == true && toggleBool.isClicked == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(CheckSound, transform.position);
            toggleText = gameObject.GetComponentInChildren<Text>();
            PlayerPrefs.SetString("User", toggleText.text.Trim());
            Debug.Log(PlayerPrefs.GetString("User"));
            panelToDisable.SetActive(false);
            panelToEnable.SetActive(true);
            toggleBool.isClicked = false;
        }
        else if (isLast == true)
        {
            toggleBool.isClicked = false;
        }
    }
}
