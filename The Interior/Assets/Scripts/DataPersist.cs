using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersist : MonoBehaviour
{
    public static DataPersist instance;

    public bool access2A = false;
    public bool access2B = false;

    public bool squareDone = false;
    public bool circleDone = false;
    public bool triDone = false;

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

    public void Check3Done()
    {
        if(squareDone && circleDone && triDone)
        {
            print("DONE!");
            //SceneManager.LoadScene(4);
        }
    }
}
