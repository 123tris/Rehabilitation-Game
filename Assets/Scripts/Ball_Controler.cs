using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controler : MonoBehaviour {
    public Rigidbody rb;
    float speed = 0.1f;

    bool vertical;
    public Ball_Spawn b_s;

	void Update () {

        if(gameObject.transform.eulerAngles.y == 0 || gameObject.transform.eulerAngles.y == 180 || gameObject.transform.eulerAngles.y == -180)
        {
            vertical = true;
        }else
        {
            vertical = false;
        }

           transform.Translate(0,0, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bumper1" && vertical == false)
        {
            gameObject.transform.Rotate(0, -90, 0);
            Debug.Log("test1");
        } else if (other.gameObject.tag == "Bumper1" && vertical == true)
        {
            gameObject.transform.Rotate(0, 90, 0);

            Debug.Log("test2");
        }
        else if (other.gameObject.tag == "Bumper2" && vertical == false)
        {
            gameObject.transform.Rotate(0, 90, 0);
            Debug.Log("test1");
        }
        else if (other.gameObject.tag == "Bumper2" && vertical == true)
        {
            gameObject.transform.Rotate(0, -90, 0);

            Debug.Log("test2");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "target")
        {
            Debug.Log("yeh bitch");
        }

    }

}
