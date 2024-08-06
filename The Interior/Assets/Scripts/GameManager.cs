using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool runChance = true;
    public bool gameEvent = false;
    public GameObject lightO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(runChance)
        {
            if(Random.Range(0f, 1f) < 1)
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
}
