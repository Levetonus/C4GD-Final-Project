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

    private IEnumerator SwitchCooldown()
    {
        yield return new WaitForSeconds(1f);
    }

    public void ToRoom1()
    {
        PlayerMovement.instance.active = false;
        StartCoroutine(SwitchCooldown());
        transform.position = r1spawn.transform.position;
        PlayerMovement.instance.active = true;
        transform.position = r1spawn.transform.position;
    }

    public void ToRoom2A()
    {
        PlayerMovement.instance.active = false;
        StartCoroutine(SwitchCooldown());
        transform.position = r2Aspawn.transform.position;
        PlayerMovement.instance.active = true;
        transform.position = r2Aspawn.transform.position;
    }

    public void ToRoom2B()
    {

    }
}
