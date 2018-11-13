using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button_3D : MonoBehaviour
{
    public UnityEvent buttonPressed = new UnityEvent();

    [SerializeField] private Transform objectToAnimate;
    [SerializeField] private bool resetsOnRelease = true;
    [HideInInspector] public bool selected;
    private bool pressed;
    private Vector3 startScale;

    private SelectionGroup group;
    private void OnEnable()
    {
        if (objectToAnimate != null && startScale == Vector3.zero) 
            startScale = objectToAnimate.localScale;
    }

    public void SetGroup(SelectionGroup group)
    {
        this.group = group;
    }

    protected virtual void Update()
    {
        if ((selected || pressed) && objectToAnimate != null)
        {
            if (startScale == Vector3.zero)
                startScale = objectToAnimate.localScale; 

            objectToAnimate.localScale = startScale * 0.8f;
        }
        else if (objectToAnimate != null)
        {
            objectToAnimate.localScale = startScale;
        }

        if (!Input.GetMouseButton(0) && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonUp(0))
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetMouseButton(0))
                    pressed = true;

                if (Input.GetMouseButtonUp(0))
                {
                    if (group != null)
                        group.SetSelected(this);
                    else
                    {
                        print("No group");
                    }

                    pressed = false;
                    if (resetsOnRelease)
                    {
                        selected = false;
                        if (objectToAnimate != null)
                            objectToAnimate.localScale = startScale;
                    }
                    buttonPressed.Invoke();
                }
            }
    }
}
