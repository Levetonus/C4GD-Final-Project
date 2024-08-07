using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    public AudioSource source;
    public FileScript file;
    void Update()
    {
        if (file.panelOpen)
        {
            //add script to have panel appear and open
            source.Play();
        }
    }
}
