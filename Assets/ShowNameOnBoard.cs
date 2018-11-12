using UnityEngine;
using UnityEngine.UI;

public class ShowNameOnBoard : MonoBehaviour
{
    private Text nameText;

    public void showName()
    {
        nameText = GetComponent<Text>();
        nameText.text = PlayerPrefs.GetString("User");
    }
}
