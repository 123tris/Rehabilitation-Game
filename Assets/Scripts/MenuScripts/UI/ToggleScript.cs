using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour {


    Text toggleText;
    public bool isToggleOn;
    public GameObject panelToEnable1, panelToEnable2;
    public GameObject panelToDisable1;
    public ToggleBool toggleBool;
    public DeleteBool deleteBool;
    public bool isLast;
    public int listPosition;
    protected List<string> accountsList;
    protected string[] accountArray;

    [FMODUnity.EventRef]
    public string CheckSound = "event:/Menu/Check";

    void Update()
    {
        if (toggleBool.isClickedToggle == true)
        {
            SelectAccount();
        }
        if (deleteBool.isClickedDelete == true)
        {
            DeletePlayerSave();
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
        if (isToggleOn == true && toggleBool.isClickedToggle == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot(CheckSound, transform.position);
            toggleText = gameObject.GetComponentInChildren<Text>();
            PlayerPrefs.SetString("User", toggleText.text.Trim());
            panelToDisable1.SetActive(false);
            panelToEnable1.SetActive(true);
            toggleBool.isClickedToggle = false;
        }
        else if (isLast == true)
        {
            toggleBool.isClickedToggle = false;
        }
    }

    void DeletePlayerSave()
    {
        accountArray = PlayerPrefsX.GetStringArray("Users");
        accountsList = new List<string>(accountArray);
        if (isToggleOn == true && deleteBool.isClickedDelete == true)
        {
            toggleText = gameObject.GetComponentInChildren<Text>();
            PlayerPrefs.DeleteKey("User_" + toggleText.text.Trim());
            PlayerPrefs.SetString("User", "");
            accountsList.RemoveAt(listPosition);
            accountArray = accountsList.ToArray();
            PlayerPrefsX.SetStringArray("Users", accountArray);
            panelToDisable1.SetActive(false);
            panelToEnable2.SetActive(true);
            deleteBool.isClickedDelete = false;
        }
        else if (isLast == true)
        {
            deleteBool.isClickedDelete = false;
        }
    }
}