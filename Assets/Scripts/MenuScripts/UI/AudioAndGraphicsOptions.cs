using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioAndGraphicsOptions :Button_3D {

    public Wilberforce.Colorblind colorblind;
    public AudioMixer audioMixer;

    public void ColourBlindOne()
    {
        colorblind.Type = 1;
    }

    public void ColourBlindTwo()
    {

        colorblind.Type = 2;
    }

    public void ColourBlindThree()
    {

        colorblind.Type = 3;
    }

    public void NoColourBlind()
    {

        colorblind.Type = 0;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void DisableVolume(bool toggle)
    {
        if(toggle == true)
        {
            
        }
        else
        {

        }
    }
}
