using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morseScript : MonoBehaviour
{
    public AudioSource morseCode;

    public void Update()
    {
        if(GameManager.instance.access3)
        {
            morseCode.Play();
        }
    }
}
