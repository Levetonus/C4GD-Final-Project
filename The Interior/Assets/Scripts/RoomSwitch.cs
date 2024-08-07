using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RoomSwitch : MonoBehaviour
{
    public static RoomSwitch instance;

    public GameObject r1spawn;
    public GameObject r2Aspawn;

    private void Start()
    {
        instance = this;
    }

    private IEnumerator SwitchCooldown(Vector3 tp)
    {
        yield return new WaitForSeconds(0.5f);
        transform.position = tp;
        PlayerMovement.instance.active = true;
    }

    public void ToRoom1()
    {
        PlayerMovement.instance.active = false;
        StartCoroutine(SwitchCooldown(r1spawn.transform.position));
    }

    public void ToRoom2A()
    {
        PlayerMovement.instance.active = false;
        StartCoroutine(SwitchCooldown(r2Aspawn.transform.position));
    }

    public void ToRoom2B()
    {

    }
}
