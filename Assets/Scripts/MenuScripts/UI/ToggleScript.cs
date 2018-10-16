using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour {


    Text toggleText;
    bool buttonPressed;
    public GameObject panelToEnable;
    public GameObject panelToDisable;
    public Button buttonToPress;

    [FMODUnity.EventRef]
    public string CheckSound = "event:/Menu/Check";

    private void Start()
    {
        buttonToPress.onClick.AddListener(ButtonIsPressed);
    }

    public void ButtonIsPressed()
    {
        buttonPressed = true;
    }

    public void AccountToggle(bool toggle)
    {
        if (toggle == true && buttonPressed == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(CheckSound, transform.position);

            toggleText = gameObject.GetComponentInChildren<Text>();
            PlayerPrefs.SetString("User", toggleText.ToString());
            PlayerPrefs.SetString("User_" + toggleText.ToString(), toggleText.ToString());
            panelToDisable.SetActive(false);
            panelToEnable.SetActive(true);
        }
    }
}
