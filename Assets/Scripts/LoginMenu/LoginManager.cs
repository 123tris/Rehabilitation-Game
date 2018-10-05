using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class LoginManager : MonoBehaviour
    {

        public bool accountDoesNotExist;

        public InputField registerAccountName; //Gebruikersnaam en wachtwoord InputField om mee te registreren
        public Text notificationTextOne;

        private void Start()
        {
            notificationTextOne.text = "";
        }

        public void DeleteSaves()
        {
            PlayerPrefs.DeleteAll();
        }

        public void CreateAccount() //Maak een account aan
        {
            if (!PlayerPrefs.HasKey("User_" + registerAccountName.text.Trim()) && registerAccountName.text.Length > 0) //Is er geen account met die naam?
            {
                StopAllCoroutines();
                StartCoroutine(NotificationTwo("Account is gecreert klik op de rechter pijl om verder te gaan klik niet op een andere knop"));
                PlayerPrefs.SetString("User_" + registerAccountName.text.Trim(), registerAccountName.text.Trim()); //Sla het account op als 'User_NAAM'
                PlayerPrefs.SetString("User", registerAccountName.text.Trim());
                accountDoesNotExist = true;
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(NotificationTwo("Account naam bestaat al"));
                accountDoesNotExist = false;
            }
        }

        private IEnumerator NotificationTwo(string _message) //Laat hier meldingen zien aan de speler
        {
            notificationTextOne.text = _message;

            yield return new WaitForSeconds(3.5f);
            notificationTextOne.text = "";
        }
    }
}