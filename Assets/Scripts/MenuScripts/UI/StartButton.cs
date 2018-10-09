using UnityEngine;
using System.Collections;

public class StartButton : Button_3D
{
    void Start()
    {
        buttonPressed.AddListener(OnStart);
    }

    void OnStart()
    {

    }

}
