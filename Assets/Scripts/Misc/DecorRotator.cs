using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorRotator : MonoBehaviour {


	void FixedUpdate () {
        transform.Rotate(Vector3.forward * 6 , Space.World);
    }
}
