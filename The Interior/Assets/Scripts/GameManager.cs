using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool access2A = false;
    public bool access2B = false;
    public bool access3 = false;

    public bool squareDone = false;
    public bool circleDone = false;
    public bool triDone = false;

    private bool runChance = true;
    public bool lightsEvent = false;
    public GameObject lightO;
    public GameObject key1;
    public GameObject key2;
    public GameObject square;

    public GameObject instructions;

    public void Start()
    {
        instance = this;

        instructions.SetActive(true);
        StartCoroutine(InstrCooldown());
    }

    private IEnumerator InstrCooldown()
    {
        yield return new WaitForSeconds(5f);
        instructions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(runChance)
        {
            if(Random.Range(0f, 1f) < 0f)
            {
                runChance = false;
                lightsEvent = true;
                lightO.SetActive(false);
                AudioManager.instance.LightsOff();
            }
            else
            {
                runChance = false;
                StartCoroutine(ChanceCooldown());
            }
        }
    }

    IEnumerator ChanceCooldown()
    {
        yield return new WaitForSeconds(30f);
    }

    public void Check3Done()
    {
        if(squareDone && circleDone && triDone)
        {
            access3 = true;
        }
    }
}
