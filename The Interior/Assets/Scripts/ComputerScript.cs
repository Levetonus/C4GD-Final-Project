using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour
{
    public GameObject computerScreen;
    private void OnMouseDown()
    {
        MouseLook.instance.active = false;
        Cursor.lockState = CursorLockMode.None;
        computerScreen.SetActive(true);
    }

    public void ExitScreen()
    {
        MouseLook.instance.active = true;
        Cursor.lockState = CursorLockMode.Locked;
        computerScreen.SetActive(false);
    }
}
