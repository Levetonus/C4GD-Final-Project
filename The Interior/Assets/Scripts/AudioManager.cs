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
    public AudioClip knocking;
    private bool person;

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
                StartCoroutine(D1());
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

    IEnumerator D1()
    {
        yield return new WaitForSeconds(2f);

        if(Random.Range(0f, 1f) < 0.4)
        {
            person = true;
            source2.clip = knocking;
            source2.Play();
        }
        
        StartCoroutine(D2());
    }

    IEnumerator D2()
    {
        yield return new WaitForSeconds(10f);
        source1.clip = dGas;
        source1.Play();

        if (person)
        {
            StartCoroutine(BodyDrop());
            
        }
        StartCoroutine(D3());
    }

    IEnumerator BodyDrop()
    {
        yield return new WaitForSeconds(3f);
        source2.clip = bodyDrop;
        source2.Play();
    }

    IEnumerator D3()
    {
        yield return new WaitForSeconds(35f);
        source1.Stop();
        decontamEvent = false;
        person = false;
    }
}
