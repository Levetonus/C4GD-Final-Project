using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileScript : MonoBehaviour
{
    public bool panelOpen = false;
    public GameObject bKey;
    private void OnMouseDown()
    {
        bKey.SetActive(true);
    }
}
