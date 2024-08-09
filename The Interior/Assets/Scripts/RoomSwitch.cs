using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RoomSwitch : MonoBehaviour
{
    public static RoomSwitch instance;

    public GameObject player;
    public GameObject playerBack;
    public GameObject playerFront;

    public GameObject r1_spawn;
    public GameObject r2A_spawn;
    public GameObject r2B_spawn;
    public GameObject r3_spawn;

    private void Start()
    {
        instance = this;
    }

    private IEnumerator SwitchCooldown(Vector3 tp)
    {
        PlayerMovement.instance.active = false;
        player.GetComponent<CharacterController>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        Vector3 dist = tp - transform.position;

        if(dist.z < 0)
        {
            player.transform.position = playerFront.transform.position;
        }
        else
        {
            player.transform.position = playerBack.transform.position;
        }
        transform.Translate(dist);
        player.GetComponent<CharacterController>().enabled = true;
        PlayerMovement.instance.active = true;
    }

    public void ToRoom1()
    {
        StartCoroutine(SwitchCooldown(r1_spawn.transform.position));
    }

    public void ToRoom2A()
    {
        GameManager.instance.access2A = true;
        StartCoroutine(SwitchCooldown(r2A_spawn.transform.position));
    }

    public void ToRoom2B()
    {
        GameManager.instance.access2B = true;
        StartCoroutine(SwitchCooldown(r2B_spawn.transform.position));
    }

    public void ToRoom3()
    {
        GameManager.instance.access3 = true;
        StartCoroutine(SwitchCooldown(r3_spawn.transform.position));
        GameManager.instance.morseCode.Play();
        StartCoroutine(GameManager.instance.RepeatCode());
    }
}
