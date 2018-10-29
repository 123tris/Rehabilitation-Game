using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauzeTrigger : MonoBehaviour
{
    private Camera mCamera = null;

    public int motionHit = 0;

    float timer = 0;

    private Renderer rend;

    private void Awake()
    {
        mCamera = Camera.main;
    }

    private void Update()
    {
        if (motionHit > 8)
        {
            if(this.gameObject.tag == "test")
            {

            }
            else
            {
                timer += Time.deltaTime;
                if (timer > 2)
                {
                    rend = gameObject.GetComponent<Renderer>();
                    rend.material.color = Color.red;
                    timer = 0.0f;
                }
            }
        }
        else
        {
            timer = 0.0f;
        }
    }
}
