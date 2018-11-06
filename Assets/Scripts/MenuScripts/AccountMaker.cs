using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AccountMaker : MonoBehaviour
{

    public InputField registerAccountName;
    public Text notificationTextOne;
    protected List<string> accountsList;
    protected string[] accountArray;
    public GameObject panelToEnable1;
    public GameObject panelToDisable1;


    public void CreateAccount()
    {
        accountArray = PlayerPrefsX.GetStringArray("Users");
        accountsList = new List<string>(accountArray);

        if (!PlayerPrefs.HasKey("User_" + registerAccountName.text) && registerAccountName.text.Length > 0)
        {
            StartCoroutine(NotificationOne("Account is gecreert"));
            PlayerPrefs.SetString("User_" + registerAccountName.text, registerAccountName.text);
            PlayerPrefs.SetString("User", registerAccountName.text);
            accountsList.Add(registerAccountName.text);
            accountArray = accountsList.ToArray();
            PlayerPrefsX.SetStringArray("Users", accountArray);
            panelToDisable1.SetActive(false);
            panelToEnable1.SetActive(true);
        }
        else
        {
            StartCoroutine(NotificationOne("Account naam bestaat al"));
        }
    }

    public void DeleteAccounts()
    {
        PlayerPrefs.DeleteAll();
    }

    private IEnumerator NotificationOne(string _message)
    {
        notificationTextOne.text = _message;

        yield return new WaitForSeconds(3.5f);
        notificationTextOne.text = "";
    }
}