using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeName : AccountMaker {

    public InputField newUserName;
    public Text notification;

   public void ChangeUserName()
    {
        accountArray = PlayerPrefsX.GetStringArray("Users");
        accountsList = new List<string>(accountArray);

        if (newUserName.text != "")
        {
            accountsList.Add(registerAccountName.text);
            accountArray = accountsList.ToArray();
            PlayerPrefsX.SetStringArray("Users", accountArray);


           // accountsList[1] = new string(newUserName.ToString());

            PlayerPrefs.SetString("User_" + PlayerPrefs.GetString("User"), newUserName.ToString());
            PlayerPrefs.SetString("User", newUserName.ToString());
            StartCoroutine(NotificationShow("naam is veranderd"));
        }
        else
        {
            StartCoroutine(NotificationShow("vul iets in"));
        }
    }

    private IEnumerator NotificationShow(string _message) //pak eerst de lijst doe een for loop kijken dan of namen gelijk zijn en verander ze;
    {
        notification.text = _message;

        yield return new WaitForSeconds(1.75f);
        notification.text = "";
    }
}
