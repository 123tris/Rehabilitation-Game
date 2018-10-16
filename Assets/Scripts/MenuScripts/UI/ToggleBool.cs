using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBool : MonoBehaviour {

    public bool buttonIsActive;

	public void ButtonPressed()
    {
        buttonIsActive = true;
    }
	
	public void ButtonLoss () {
        buttonIsActive = false;
	}
}
