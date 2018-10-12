using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour {


    Text toggleText;

    [FMODUnity.EventRef]
    public string CheckSound = "event:/Menu/Check";

    public void AccountToggle(bool toggle)
    {
        if (toggle == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(CheckSound, transform.position);

            toggleText = gameObject.GetComponentInChildren<Text>();
            PlayerPrefs.SetString("User", toggleText.ToString());
            PlayerPrefs.SetString("User_" + toggleText.ToString(), toggleText.ToString());
        }
    }
}
