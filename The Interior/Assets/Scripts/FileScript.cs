using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileScript : MonoBehaviour
{
    public bool panelOpen = false;
    public AudioSource source;
    public GameObject bKey;
    private void OnMouseDown()
    {
        bKey.SetActive(true);
        source.Play();
    }
}
