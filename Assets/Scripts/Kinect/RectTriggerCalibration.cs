using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using saveGame;
using System.IO;

public class RectTriggerCalibration : MonoBehaviour
{
    private Camera mCamera = null;

    public int motionHit = 0;

    bool calibrationActive = false;

    public Text calibrationText;
    public GameObject calibrationButton;
    public GameObject resetButton;
    public GameObject togglegui;

    public GameObject[] sliders;

    float timer = 0;

    public MeasureDepthCalibration mdc;

    public PlayerData data;

    string json;

    private void Start()
    {
        mdc = FindObjectOfType<MeasureDepthCalibration>();
        mCamera = Camera.main;
    }

    void Update()
    {
        if (calibrationActive)
        {
            if (mdc.mTriggerPoints.Count >= 75)
            {
                timer += Time.deltaTime;
                if(timer > 0.01f)
                {
                    mdc.mDepthSensitivity -= 0.001f;
                    mdc.mWallDepth -= 0.01f;
                }
            }
            else
            {
                data.SavedWallDepth = mdc.mWallDepth;
                data.SavedDepthSensitivity = mdc.mDepthSensitivity;
                data.SavedTopCutOff = mdc.topCutOff.value;
                data.SavedBottomCutOff = mdc.bottomCutOff.value;
                data.SavedLeftCutOff = mdc.leftCutOff.value;
                data.SavedRightCutOff = mdc.rightCutOff.value;
                data.ShowGui = mdc.Gui.isOn;
                json = JsonUtility.ToJson(data);
                File.WriteAllText(Application.dataPath + "/StreamingAssets/calibratieFile.json", json);

                foreach (GameObject slider in sliders)
                {
                    slider.SetActive(true);
                }
                calibrationText.text = "Caliberen klaar!";
                calibrationButton.SetActive(true);
                resetButton.SetActive(true);
                togglegui.SetActive(true);
                calibrationActive = false;
            }
        }
    }

    public void ActivateCalbration()
    {
        foreach(GameObject slider in sliders)
        {
            slider.SetActive(false);
        }
        mdc.mWallDepth = 10.0f;
        mdc.mDepthSensitivity = 1.0f;
        calibrationText.text = "";
        motionHit = 0;
        togglegui.SetActive(false);
        calibrationButton.SetActive(false);
        resetButton.SetActive(false);
        StartCoroutine(waitforcalibration(1.0f));
    }

    public void resetVar()
    {
        mdc.mWallDepth = 10.0f;
        mdc.mDepthSensitivity = 1.0f;
        mdc.topCutOff.value = 1.0f;
        mdc.bottomCutOff.value = -1.0f;
        mdc.leftCutOff.value = -1.0f;
        mdc.rightCutOff.value = 1.0f;
    }

    IEnumerator waitforcalibration(float t)
    {
        yield return new WaitForSeconds(t);
        calibrationActive = true;
    }
}
