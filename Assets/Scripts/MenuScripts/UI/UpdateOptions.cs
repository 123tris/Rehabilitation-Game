using UnityEngine;
using UnityEngine.UI;
public class UpdateOptions : MonoBehaviour
{
    [SerializeField] private Camera_Change cameraChange;

    [SerializeField] private Button_3D colorBlind1, colorBlind2, colorBlind3, colorBlindNone;
    [SerializeField] private Toggle cameraToggle2D;
    
    [SerializeField] private Slider soundEffects, music, ambiance;
    [SerializeField] private Toggle soundOn;

    private string SoundFXPath = "vca:/Sound FX";
    private string MusicPath = "vca:/Music";
    private string AmbiancePath = "vca:/Ambiance";

    private string masterBusString = "Bus:/";
    private FMOD.Studio.Bus masterBus;

    private FMOD.Studio.VCA SoundFX;
    private FMOD.Studio.VCA Music;
    private FMOD.Studio.VCA Ambiance;

    [SerializeField] private Wilberforce.Colorblind colorblind;

    private void OnEnable()
    {
        SoundFX = FMODUnity.RuntimeManager.GetVCA(SoundFXPath);
        Music = FMODUnity.RuntimeManager.GetVCA(MusicPath);
        Ambiance = FMODUnity.RuntimeManager.GetVCA(AmbiancePath);
        masterBus = FMODUnity.RuntimeManager.GetBus(masterBusString);

        //Audio
        float tmp;
        float s, m, a;
        Music.getVolume(out m, out tmp);
        Ambiance.getVolume(out a, out tmp);
        SoundFX.getVolume(out s, out tmp);

        soundEffects.value = s;
        music.value = m;
        ambiance.value = a;

        float v;
        masterBus.getVolume(out v, out tmp);
        soundOn.isOn = v > 0;

        UpdateColorBlindButtons();

        cameraToggle2D.isOn = cameraChange.twoD;
    }

    public void UpdateColorBlindButtons()
    {
        //Color blindness
        switch (colorblind.Type)
        {
            case 0:
                colorBlindNone.selected = true;
                colorBlind1.selected = false;
                colorBlind2.selected = false;
                colorBlind3.selected = false;
                break;
            case 1:
                colorBlindNone.selected = false;
                colorBlind1.selected = true;
                colorBlind2.selected = false;
                colorBlind3.selected = false;
                break;
            case 2:
                colorBlindNone.selected = false;
                colorBlind1.selected = false;
                colorBlind2.selected = true;
                colorBlind3.selected = false;
                break;
            case 3:
                colorBlindNone.selected = false;
                colorBlind1.selected = false;
                colorBlind2.selected = false;
                colorBlind3.selected = true;
                break;
        }
    }
}
