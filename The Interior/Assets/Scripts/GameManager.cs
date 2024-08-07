using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Scene scene;

    private bool runChance = true;
    public bool gameEvent = false;
    public GameObject lightO;
    public GameObject key1;
    public GameObject key2;
    public GameObject square;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Add the listener to be called when a scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Store the creating scene as the scene to trigger start
        scene = SceneManager.GetActiveScene();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // return if not the start calling scene
        if (!string.Equals(scene.path, this.scene.path)) return;

        Debug.Log("Re-Initializing", this);
        // do your "Start" stuff here
        Objects();
    }

    public void Objects()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 && !DataPersist.instance.access2A)
        {
            key1.SetActive(true);
        }
        if (SceneManager.GetActiveScene().buildIndex == 0 && !DataPersist.instance.access2B)
        {
            key2.SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && !DataPersist.instance.squareDone)
        {
            square.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(runChance)
        {
            if(Random.Range(0f, 1f) < 0.2f)
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
