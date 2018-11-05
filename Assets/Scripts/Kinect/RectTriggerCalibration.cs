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
            if (mdc.mTriggerPoints.Count >= 50)
            {
                timer += Time.deltaTime;
                //if(timer > 0.01f)
                {
                    mdc.mDepthSensitivity -= 0.001f;
                    mdc.mWallDepth -= 0.01f;
                }
            }
            else
            {
                data.SavedWallDepth = mdc.mWallDepth;
                data.SavedDepthSensitivity = mdc.mDepthSensitivity;
                data.SavedTopCutOff = mdc.mTopCutOff;
                data.SavedBottomCutOff = mdc.mBottomCutOff;
                data.SavedLeftCutOff = mdc.mLeftCutOff;
                data.SavedRightCutOff = mdc.mRightCutOff;
                json = JsonUtility.ToJson(data);
                File.WriteAllText(Application.dataPath + "/StreamingAssets/calibratieFile.json", json);
                calibrationText.text = "Caliberen klaar!";
                calibrationButton.SetActive(true);
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
        calibrationText.text = "";
        motionHit = 0;
        calibrationActive = true;
        calibrationButton.SetActive(false);
    }
}
