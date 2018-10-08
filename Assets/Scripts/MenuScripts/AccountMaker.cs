using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class AccountMaker : MonoBehaviour
    {

        public bool accountDoesNotExist;

        public InputField registerAccountName; 
        public Text notificationTextOne;

        private void Start()
        {
            notificationTextOne.text = "";
        }



        public void CreateAccount()
        {
            if (!PlayerPrefs.HasKey("User_" + registerAccountName.text.Trim()) && registerAccountName.text.Length > 0)
            {
                StartCoroutine(NotificationTwo("Account is gecreert klik op de rechter pijl om verder te gaan klik niet op een andere knop"));
                PlayerPrefs.SetString("User_" + registerAccountName.text.Trim(), registerAccountName.text.Trim());
                PlayerPrefs.SetString("User", registerAccountName.text.Trim());
                accountDoesNotExist = true;
            }
            else
            {
                StartCoroutine(NotificationTwo("Account naam bestaat al"));
                accountDoesNotExist = false;
            }
        }

        private IEnumerator NotificationTwo(string _message)
        {
            notificationTextOne.text = _message;

            yield return new WaitForSeconds(3.5f);
            notificationTextOne.text = "";
        }
    }
}