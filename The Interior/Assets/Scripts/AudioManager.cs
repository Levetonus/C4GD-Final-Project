using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private bool runChance = true;
    public AudioSource source1;
    public AudioSource source2;

    public AudioClip dAlarm;
    public AudioClip dGas;
    public AudioClip bodyDrop;
    public AudioClip knocking;
    private bool person = false;

    public AudioClip lights;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(runChance)
        {
            if(Random.Range(0f, 1f) < 0.25)
            {
                runChance = false;
                source1.clip = dAlarm;
                source1.Play();
                StartCoroutine(D1());
            }
            else
            {
                runChance = false;
                StartCoroutine(gasEventCooldown());
            }
        }
    }
    public void LightsOff()
    {
        source1.clip = lights;
        source1.Play();
    }

    public void LightsOn()
    {
        source1.clip = lights;
        source1.Play();
    }


    IEnumerator gasEventCooldown()
    {
        yield return new WaitForSeconds(10f);
        runChance = true;
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
        runChance = true;
        person = false;
    }
}
