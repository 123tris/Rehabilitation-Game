using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controler : MonoBehaviour {
    public Rigidbody rb;
    float speed = 0.1f;

    bool up;
    bool down;

	void Update () {

           transform.Translate(0,0, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bumper1" && down == true)
        {
            gameObject.transform.Rotate(0, -90, 0);
            Debug.Log("blm");
        }

    }


}
