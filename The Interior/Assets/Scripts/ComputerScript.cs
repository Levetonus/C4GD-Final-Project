using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour
{
    public GameObject computerScreen;
    private void OnMouseDown()
    {
        Cursor.lockState = CursorLockMode.None;
        computerScreen.SetActive(true);
    }

    public void ExitScreen()
    {
        Cursor.lockState = CursorLockMode.Locked;
        computerScreen.SetActive(false);
    }
}
