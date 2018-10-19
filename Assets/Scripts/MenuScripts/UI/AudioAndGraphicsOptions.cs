using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioAndGraphicsOptions :Button_3D {

    string SoundFXPath = "vca:/Sound FX";
    string MusicPath = "vca:/Music";
    string AmbiancePath = "vca:/Ambiance";

    string masterBusString = "Bus:/";
    FMOD.Studio.Bus masterBus;

    public Wilberforce.Colorblind colorblind;

    FMOD.Studio.VCA SoundFX;
    FMOD.Studio.VCA Music;
    FMOD.Studio.VCA Ambiance;

    private void Start()
    {
        SoundFX= FMODUnity.RuntimeManager.GetVCA(SoundFXPath);
        Music = FMODUnity.RuntimeManager.GetVCA(MusicPath);
        Ambiance = FMODUnity.RuntimeManager.GetVCA(AmbiancePath);
        masterBus = FMODUnity.RuntimeManager.GetBus(masterBusString);
    }

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

    public void SetSoundFXVolume(float volume)
    {
        SoundFX.setVolume(volume);
    }

    public void SetMusicVolume(float volume)
    {
        Music.setVolume(volume);
    }

    public void SetAmbainceVolume(float volume)
    {
        Ambiance.setVolume(volume);
    }



    public void DisableVolume(bool toggle)
    {
        if(toggle == true)
        {
            masterBus.setVolume(1);
        }
        else
        {
            masterBus.setVolume(0);
        }
    }
}
