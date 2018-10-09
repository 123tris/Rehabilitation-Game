using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    [FMODUnity.EventRef]
    public string music = "event:/Music/Music";

    FMOD.Studio.EventInstance musicEv;

    void Start () {

        musicEv = FMODUnity.RuntimeManager.CreateInstance(music);

        musicEv.start();

	}
	
}
