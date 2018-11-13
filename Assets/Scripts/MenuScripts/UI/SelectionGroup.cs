using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionGroup : MonoBehaviour
{
    public List<Button_3D> buttons;

    private void OnEnable()
    {
        foreach (Button_3D button in buttons)
            button.SetGroup(this);
    }

    public void SetSelected(Button_3D button)
    {
        foreach (Button_3D b in buttons)
            b.selected = false;
        button.selected = true;
    }
}
