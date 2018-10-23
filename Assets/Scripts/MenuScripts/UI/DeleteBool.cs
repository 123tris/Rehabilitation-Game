using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBool : Button_3D {

    public bool isClickedDelete;

    void Start()
    {
        buttonPressed.AddListener(DeleteAccountBool);
    }

    void DeleteAccountBool()
    {
        isClickedDelete = true;
    }
}
