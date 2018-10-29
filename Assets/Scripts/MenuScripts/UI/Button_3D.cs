using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button_3D : MonoBehaviour
{
    public UnityEvent buttonPressed = new UnityEvent();

    void Start()
    {
    }

    protected virtual void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject && Input.GetMouseButtonDown(0))
            {
                buttonPressed.Invoke();
            }
            else
            {
                //Debug.Log(null);
            }
        }
    }
}
