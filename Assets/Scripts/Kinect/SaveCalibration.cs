﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

namespace saveGame
{
    public class SaveCalibration : MonoBehaviour
    {
        MeasureDepthCalibration mdc;
        MeasureDepth md;
        PlayerData playerdata;
        string json;

        // Use this for initialization
        void Start()
        {
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name == "Automatic calibration test")
            {
                json = File.ReadAllText(Application.dataPath + "/StreamingAssets/calibratieFile.json");
                playerdata = JsonUtility.FromJson<PlayerData>(json);
                mdc = FindObjectOfType<MeasureDepthCalibration>();
                mdc.mWallDepth = playerdata.SavedWallDepth;
                mdc.mDepthSensitivity = playerdata.SavedDepthSensitivity;
                mdc.topCutOff.value = playerdata.SavedTopCutOff;
                mdc.bottomCutOff.value = playerdata.SavedBottomCutOff;
                mdc.leftCutOff.value = playerdata.SavedLeftCutOff;
                mdc.rightCutOff.value = playerdata.SavedRightCutOff;
                mdc.Gui.isOn = playerdata.ShowGui;
                mdc.zoom = playerdata.zoomSaved;
                mdc.offset = playerdata.offsetSaved;
            }
            else if (scene.name == "TimurScene")
            {
                json = File.ReadAllText(Application.dataPath + "/StreamingAssets/calibratieFile.json");
                playerdata = JsonUtility.FromJson<PlayerData>(json);
                md = FindObjectOfType<MeasureDepth>();
                md.mWallDepth = playerdata.SavedWallDepth;
                md.mDepthSensitivity = playerdata.SavedDepthSensitivity;
                md.mTopCutOff = playerdata.SavedTopCutOff;
                md.mBottomCutOff = playerdata.SavedBottomCutOff;
                md.mLeftCutOff = playerdata.SavedLeftCutOff;
                md.mRightCutOff = playerdata.SavedRightCutOff;
                md.zoom = playerdata.zoomSaved;
                md.offset = playerdata.offsetSaved;
                md.inversedCoords = playerdata.InversedCoords;
            }
        }
    }
    [System.Serializable]
    public class PlayerData
    {
        public float SavedWallDepth;

        public float SavedDepthSensitivity;

        public float SavedTopCutOff;

        public float SavedBottomCutOff;

        public float SavedLeftCutOff;

        public float SavedRightCutOff;

        public bool ShowGui;

        public float zoomSaved;

        public Vector2Int offsetSaved;

        public bool InversedCoords;
    }
}
