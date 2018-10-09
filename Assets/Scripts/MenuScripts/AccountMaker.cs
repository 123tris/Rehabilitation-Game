using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class AccountMaker : MonoBehaviour
    {

        public InputField registerAccountName;
        public Text notificationTextOne;
        public List<string> accountsList;
        public string[] accountArray;

        private void Start()
        {
            notificationTextOne.text = "";
        }

        public void CreateAccount()
        {
            accountArray = PlayerPrefsX.GetStringArray("Users");
            accountsList = new List<string>(accountArray);
            Debug.Log(accountsList[3]);
            if (!PlayerPrefs.HasKey("User_" + registerAccountName.text) && registerAccountName.text.Length > 0)
            {
                StartCoroutine(NotificationTwo("Account is gecreert"));
                PlayerPrefs.SetString("User_" + registerAccountName.text, registerAccountName.text);
                PlayerPrefs.SetString("User", registerAccountName.text);
                accountsList.Add(registerAccountName.text);
                accountArray = accountsList.ToArray();
                PlayerPrefsX.SetStringArray("Users", accountArray);
            }
            else
            {
                StartCoroutine(NotificationTwo("Account naam bestaat al"));
            }
        }

        public void DeleteAccount()
        {
            PlayerPrefs.DeleteAll();
        }

        private IEnumerator NotificationTwo(string _message)
        {
            notificationTextOne.text = _message;

            yield return new WaitForSeconds(3.5f);
            notificationTextOne.text = "";
        }
    }
}