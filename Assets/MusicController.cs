using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

    [FMODUnity.EventRef]
    public string music = "event:/Music/Music";

    [FMODUnity.EventRef]
    public string Bar = "event:/Ambiance/Bar";

    [FMODUnity.EventRef]
    public string ChantDissapointedSound = "event:/Ambiance/Wrong";

    [FMODUnity.EventRef]
    public string ChantCheeringSound = "event:/Ambiance/Correct";

    FMOD.Studio.EventInstance musicEv;

    FMOD.Studio.EventInstance BarEV;

    bool audioSpawned;

    private void Start()
    {
        audioSpawned = false;
    }

    void Awake () {
        SpawnAudio();

        Debug.Log(audioSpawned);

        audioSpawned = PlayerPrefsX.GetBool("audiospawned", audioSpawned);
    }

    void SpawnAudio()
    {
        if (audioSpawned == false)
        {
            Debug.Log("Audio spawned");

           BarEV = FMODUnity.RuntimeManager.CreateInstance(Bar);
         
            BarEV.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

           BarEV.start();

            musicEv = FMODUnity.RuntimeManager.CreateInstance(music);

            musicEv.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));

            musicEv.start();

            PlayerPrefsX.SetBool("audiospawned", audioSpawned = true);
        }
    }
    private void Update()
    {
        Chanting();
          
    }

    public void GameStarted()
    {
        BarEV.setParameterValue("GameStarted", 1f);
        Debug.Log("Gamestarted_bigBoard");
    }	

    public void Chanting()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            FMODUnity.RuntimeManager.PlayOneShot(ChantCheeringSound, transform.position);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            FMODUnity.RuntimeManager.PlayOneShot(ChantDissapointedSound, transform.position);
        }
       
    }
}
