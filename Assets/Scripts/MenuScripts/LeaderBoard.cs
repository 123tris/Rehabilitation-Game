using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : AccountMaker
{
    public List<Text> Name;
        


    public void Awake()
    {
        accountArray = PlayerPrefsX.GetStringArray("Users");
        accountsList = new List<string>(accountArray);
        for (int i = 0; i < accountsList.Count; i++)
        {
    
        }
    }
}
