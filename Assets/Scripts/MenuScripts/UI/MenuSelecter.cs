using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts
{
    public class MenuSelecter : MonoBehaviour
    {
        public GameObject buttonGroup1, buttonGroup2, buttonGroup3, buttonGroup4, buttonGroup5, buttonGroup6;
        public GameObject noPunishmentBox, cantFailBox, rewardBox;
        public bool noPunishmentButton, cantFailButton, rewardButton;
        Image rend1, rend2, rend3;
        public Material onMaterial, offMaterial;
        //public LoginManager loginManager;

        private void Start()
        {
            rend1 = noPunishmentBox.GetComponent<Image>();
            rend2 = cantFailBox.GetComponent<Image>();
            rend3 = rewardBox.GetComponent<Image>();
        }

        public void NoPunishmentToggle(bool toggle)
        {
            noPunishmentButton = toggle;
            if (noPunishmentButton == true)
            {
                rend1.material = onMaterial;
                //code om deze setting aan te zetten
            }
            else
            {
                //code om deze setting uit te zetten
                rend1.material = offMaterial;
            }
        }

        public void CantFailToggle(bool toggle)
        {
            cantFailButton = toggle;
            if (cantFailButton == true)
            {
                rend2.material = onMaterial;
                //code om deze setting aan te zetten
            }
            else
            {
                rend2.material = offMaterial;
                //code om deze setting uit te zetten
            }
        }

        public void RewardToggle(bool toggle)
        {
            rewardButton = toggle;
            if (rewardButton == true)
            {
                //code om deze setting aan te zetten
                rend3.material = onMaterial;
            }
            else
            {
                //code om deze setting uit te zetten
                rend3.material = offMaterial;
            }
        }


        public void StartGameButton()
        {
            buttonGroup1.SetActive(false);
            buttonGroup6.SetActive(true);
        }

        public void NewGameButton()
        {
            buttonGroup6.SetActive(false);
            buttonGroup2.SetActive(true);
        }

        public void OptionsButton()
        {
            buttonGroup1.SetActive(false);
            buttonGroup3.SetActive(true);
        }

        public void ExitButton()
        {
            Application.Quit();
        }

        public void WomanButton()
        {
            SceneManager.LoadScene("Customizer");
        }

        public void ManButton()
        {
            SceneManager.LoadScene("Customizer");
        }

        public void ContinueButton()
        {
            buttonGroup6.SetActive(false);
            buttonGroup4.SetActive(true);
        }

        //public void MakeAccountVerder()
        //{
        //    if (loginManager.accountDoesNotExist == true)
        //    {               
        //        buttonGroup2.SetActive(false);
        //        buttonGroup5.SetActive(true);
        //    }
        //}

        public void BackButton()
        {
            buttonGroup6.SetActive(false);
            buttonGroup5.SetActive(false);
            buttonGroup4.SetActive(false);
            buttonGroup3.SetActive(false);
            buttonGroup2.SetActive(false);
            buttonGroup1.SetActive(true);
        }
    }
}
