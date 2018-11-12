using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using saveGame;
using System.IO;
using UnityEngine.SceneManagement;

public class RectTriggerCalibration : MonoBehaviour
{
    private Camera mCamera = null;

    public int motionHit = 0;

    bool calibrationActive = false;

    public Text calibrationText;

    public InputField Zoom;
    public InputField offsetX;
    public InputField offsetY;

    public GameObject[] SetFalse;

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
        mdc.zoom = float.Parse(Zoom.text);
        mdc.offset.x = int.Parse(offsetX.text);
        mdc.offset.y = int.Parse(offsetY.text);


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
                data.zoomSaved = mdc.zoom;
                data.offsetSaved = mdc.offset;
                data.InversedCoords = mdc.inversedCoords;
                json = JsonUtility.ToJson(data);
                File.WriteAllText(Application.dataPath + "/StreamingAssets/calibratieFile.json", json);

                foreach (GameObject objects in SetFalse)
                {
                    objects.SetActive(true);
                }
                calibrationText.text = "Caliberen klaar!";
                calibrationActive = false;
            }
        }
    }

    public void ActivateCalbration()
    {
        foreach(GameObject objects in SetFalse)
        {
            objects.SetActive(false);
        }
        mdc.mWallDepth = 10.0f;
        mdc.mDepthSensitivity = 1.0f;
        calibrationText.text = "";
        motionHit = 0;
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

    public void BackToMenu()
    {
        SceneManager.LoadScene("TimurScene");
    }


    IEnumerator waitforcalibration(float t)
    {
        yield return new WaitForSeconds(t);
        calibrationActive = true;
    }
}
