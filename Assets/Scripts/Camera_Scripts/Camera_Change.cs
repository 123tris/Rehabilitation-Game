using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Change : MonoBehaviour
{
    public Animator animator;

    Camera cameraC;
    public GameObject camera_rot;
    bool animDone;
    public bool twoD;
    public bool ThreeD;
    private void Awake()
    {
        cameraC = GetComponent<Camera>();
        animDone = true;
        ThreeD = true;
    }

    public void GoTo2D()
    {
        cameraC.orthographic = true;
        twoD = true;
        ThreeD = false;
        animator.SetBool("2D", true);
        animator.SetBool("3D", false);
    }
    public void GoTo3D()
    {
        cameraC.orthographic = false;
        ThreeD = true;
        twoD = false;
        animator.SetBool("3D", true);
        animator.SetBool("2D", false);
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
