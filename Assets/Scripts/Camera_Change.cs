using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Change : MonoBehaviour {

    public Animator animator;

    Camera camera;
    public GameObject camera_rot;
    bool animDone;
    bool twoD;
    bool ThreeD;
    private void Awake()
    {
        camera = GetComponent<Camera>();
        animDone = true;
        twoD = true;
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha2) && animDone == true && twoD == false)
        {
            camera.orthographic = true;
            twoD = true;
            ThreeD = false;
        animator.SetBool("2D", true);
        animator.SetBool("3D", false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && animDone == true && ThreeD == false)
        {
            camera.orthographic = false;
            ThreeD = true;
            twoD = false;
        animator.SetBool("3D", true);
        animator.SetBool("2D", false);
        }
    }
    void AnimationFinished()
    {
    animDone = true;
    }

    void AnimationBusy()
    {
    animDone = false;

    }
}
