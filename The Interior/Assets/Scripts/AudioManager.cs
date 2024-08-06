using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool decontamEvent = false;
    public bool waiting = false;
    public AudioSource source1;
    public AudioSource source2;
    public AudioClip dAlarm;
    public AudioClip dGas;
    public AudioClip bodyDrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!decontamEvent && !waiting)
        {
            if(Random.Range(0f, 1f) < 0.25)
            {
                decontamEvent = true;
                source1.clip = dAlarm;
                source1.Play();
                StartCoroutine(alarm());
            }
            else
            {
                waiting = true;
                StartCoroutine(gasEventCooldown());
            }
        }
    }

    IEnumerator gasEventCooldown()
    {
        yield return new WaitForSeconds(10f);
        waiting = false;
    }

    IEnumerator alarm()
    {
        yield return new WaitForSeconds(12f);
        source1.clip = dGas;
        source1.Play();

        StartCoroutine(body());
    }

    IEnumerator body()
    {
        yield return new WaitForSeconds(5f);
        if (Random.Range(0f, 1f) < 0.5)
        {
            source2.clip = bodyDrop;
            source2.Play();
        }
        StartCoroutine(gas());
    }

    IEnumerator gas()
    {
        yield return new WaitForSeconds(30f);
        source1.Stop();
        decontamEvent = false;
    }
}
