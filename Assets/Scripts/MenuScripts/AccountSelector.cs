using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccountSelector : AccountMaker
{

    public GameObject scrollView;
    public GameObject toggleObject;
    Text toggleText;
    public ToggleBool toggleBool;

    public void Start()
    {
        accountArray = PlayerPrefsX.GetStringArray("Users");
        accountsList = new List<string>(accountArray);
        for (int i = 0; i < accountsList.Count; i++)
        {
            GameObject instantiatedObject = Instantiate(toggleObject, scrollView.transform);
            toggleText = instantiatedObject.GetComponentInChildren<Text>();
            toggleText.text = accountsList[i];
            instantiatedObject.GetComponent<Toggle>().group = scrollView.GetComponent<ToggleGroup>();
            instantiatedObject.GetComponent<ToggleScript>().panelToDisable = panelToDisable;
            instantiatedObject.GetComponent<ToggleScript>().panelToEnable = panelToEnable;
            instantiatedObject.GetComponent<ToggleScript>().toggleBool = toggleBool;
            if(i == accountsList.Count - 1)
            {
                instantiatedObject.GetComponent<ToggleScript>().isLast = true;
            }
            else
            {
                instantiatedObject.GetComponent<ToggleScript>().isLast = false;
            }
        }
    }

    public void DeletePlayerSave()
    {
        PlayerPrefs.DeleteKey("User_" + toggleText.text.Trim());
        PlayerPrefs.SetString("User", "");
    }

    public void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
    }

}
