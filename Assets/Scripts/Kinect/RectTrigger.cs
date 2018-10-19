using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectTrigger : MonoBehaviour
{
    Ball_Spawn ballSpawn;

    [Range(0, 10)]
    public int mSensitivity = 5;

    public bool mIsTriggered = false;

    public float i = 0;

    private Camera mCamera = null;
    public RectTransform mConfirmTransform = null;
    private RectTransform mRectTransform = null;
    private Renderer mMaterial = null;

    public int motionHit = 0;

    public int mCount = 0;

    float timer = 0;

    private void Awake()
    {
        ballSpawn = FindObjectOfType<Ball_Spawn>();
        mCamera = Camera.main;
        mRectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (motionHit > 15)
        {
            timer += Time.deltaTime;
            if (ballSpawn.rend == null && timer > 2)
            {
                ballSpawn.target = this.gameObject;
                gameObject.name = "target";
                GetComponent<Renderer>().sharedMaterial = ballSpawn.clicked_mat;
                ballSpawn.rend = GetComponent<Renderer>();
                ballSpawn.SpawnBall();
                timer = 0.0f;
            }
        }
        else
        {
            timer = 0.0f;
        }
    }
}
