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
    }//hij doet het maar een keer omdat hij na de eerste keer dat je hem doet al meteen weer uitzet
    //maak een prefab en spaan die als childe onder elke toggle

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
            PlayerPrefs.SetString("User", toggleText.ToString());
            PlayerPrefs.SetString("User_" + toggleText.ToString(), toggleText.ToString());
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
