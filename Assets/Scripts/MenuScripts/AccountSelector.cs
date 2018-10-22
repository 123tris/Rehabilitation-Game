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
    public DeleteBool deleteBool;
    public GameObject panelToEnable2;

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
            instantiatedObject.GetComponent<ToggleScript>().panelToDisable1 = panelToDisable1;
            instantiatedObject.GetComponent<ToggleScript>().panelToEnable1 = panelToEnable1;
            instantiatedObject.GetComponent<ToggleScript>().panelToEnable2 = panelToEnable2;
            instantiatedObject.GetComponent<ToggleScript>().toggleBool = toggleBool;
            instantiatedObject.GetComponent<ToggleScript>().deleteBool = deleteBool;
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

    public void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
    }

}
