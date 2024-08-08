using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileScript : MonoBehaviour
{
    public bool panelOpen = false;
    public AudioSource source;
    public GameObject bKey;
    public void onFileClick()
    {
        bKey.SetActive(true);
        source.Play();
        print("mousedown");
        GameManager.instance.closeScreen();
        RoomSwitch.instance.ToRoom3();
    }
}
