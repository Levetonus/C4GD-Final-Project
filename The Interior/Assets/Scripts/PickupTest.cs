using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class PickupTest : MonoBehaviour
{
    public static PickupTest instance;

    public GameObject unselected;
    public GameObject selected;

    public GameObject cam;
    public RaycastHit hit;
    public int currentInventorySpot = 0;
    public bool hasKey1 = false;
    public bool hasKey2 = false;
    public bool hasSquare = false;
    public bool hasTriangle = false;
    public bool hasCircle = false;
    public bool hasKeyWhite4 = false;
    public int equipped;
    public List<GameObject> inventory;
    public List<UnityEngine.Sprite> images;

    public UnityEngine.Sprite defaultImage;
    public Color defaultColor;

    void Start()
    {
        defaultImage = inventory[0].GetComponent<Image>().sprite;
        defaultColor = inventory[0].GetComponent<Image>().color;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            equipped = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            equipped = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            equipped = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            equipped = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            equipped = 4;
        }

        for(int i = 0; i < 5; i++)
        {
            if(i == equipped)
            {
                inventory[i].GetComponent<Image>().color = new Color(100, 0, 0);
            }
            else
            {
                inventory[i].GetComponent<Image>().color = defaultColor;
            }
        }

        if (Input.GetMouseButtonDown(0) && hit.collider != null && currentInventorySpot < 5)
        {
            //add ui raw images with picutres of the other pickupable objects and move them to the inventory list
            //give the pickupable objects the following tags
            //this piece of code: inventory[0].transform.position = new Vector3((currentInventorySpot*45)-90+204,-90+114.75f,0);
            //is placing the images to pretty much random positions, which is why I added the 204 and 114.75f, but it's still doing it

            GameObject gameObject = hit.collider.gameObject;

            if (gameObject.CompareTag("Key1"))
            {
                hasKey1 = true;
                inventory[currentInventorySpot].GetComponent<Image>().sprite = images[0];
                currentInventorySpot += 1;
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Key2"))
            {
                hasKey2 = true;
                inventory[currentInventorySpot].GetComponent<Image>().sprite = images[1];
                currentInventorySpot += 1;
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("square"))
            {
                hasSquare = true;

                currentInventorySpot += 1;
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("triangle"))
            {
                hasTriangle = true;

                currentInventorySpot += 1;
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("circle"))
            {
                hasCircle = true;

                currentInventorySpot += 1;
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("keyWhite4"))
            {
                hasKeyWhite4 = true;

                currentInventorySpot += 1;
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Keyhole1"))
            {
                if(hasKey1 && inventory[equipped].GetComponent<Image>().sprite == images[0])
                {
                    inventory[equipped].GetComponent<Image>().sprite = defaultImage;
                    print("PROCEED TO NEXT LEVEL");
                }
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 fwd = cam.transform.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 1 << 7))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            selected.SetActive(true);
            unselected.SetActive(false);
        }
        else
        {
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            selected.SetActive(false);
            unselected.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        
    }
}
