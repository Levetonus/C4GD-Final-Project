using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool access2A = false;
    public bool access2B = false;

    public bool squareDone = false;
    public bool circleDone = false;
    public bool triDone = false;

    private bool runChance = true;
    public bool gameEvent = false;
    public GameObject lightO;
    public GameObject key1;
    public GameObject key2;
    public GameObject square;

    public void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(runChance)
        {
            if(Random.Range(0f, 1f) < 0f) // reset to 0.2f
            {
                runChance = false;
                gameEvent = true;
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
            print("done");
        }
    }
}
