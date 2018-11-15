using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoxHighlight : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (MeshRenderer item in GetComponentsInChildren<MeshRenderer>())
        {
            item.enabled = false;
        }
    }
}
