using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileScript : MonoBehaviour
{
    public bool panelOpen = false;
    private void OnMouseDown()
    {
        panelOpen = true;
    }
}
