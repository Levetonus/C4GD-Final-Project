using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersist : MonoBehaviour
{
    public static DataPersist instance;

    public bool access2A = false;
    public bool access2B = false;
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
