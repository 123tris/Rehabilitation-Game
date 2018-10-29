using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectTrigger : MonoBehaviour
{
    Ball_Spawn ballSpawn;

    private Camera mCamera = null;
    private Renderer mMaterial = null;

    public int motionHit = 0;

    float timer = 0;

    private void Awake()
    {
        ballSpawn = FindObjectOfType<Ball_Spawn>();
        mCamera = Camera.main;
    }

    public void CheckHit()
    {
        if (motionHit > 8)
        {
            timer += Time.deltaTime;
            if (ballSpawn.rend == null && timer > 2)
            {
                if(gameObject.tag == "PauzeButtons")
                {
                    Debug.Log("Pauze test");
                    timer = 0.0f;
                }
                else if(ballSpawn.rend == null)
                {
                    ballSpawn.target = this.gameObject;
                    gameObject.name = "target";
                    GetComponent<Renderer>().sharedMaterial = ballSpawn.clicked_mat;
                    ballSpawn.rend = GetComponent<Renderer>();
                    ballSpawn.SpawnBall();
                    timer = 0.0f;
                }
            }
        }
        else
        {
            timer = 0.0f;
        }
        motionHit = 0;
    }
}
