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
    public bool hasKeyWhite2A = false;
    public bool hasKeyWhite2B = false;
    public bool hasSquare = false;
    public bool hasTriangle = false;
    public bool hasCircle = false;
    public bool hasKeyWhite4 = false;
    public float equipped;
    public List<GameObject> inventory;
    public List<UnityEngine.Sprite> images;

    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && hit.collider != null && currentInventorySpot < 5)
        {
            //add ui raw images with picutres of the other pickupable objects and move them to the inventory list
            //give the pickupable objects the following tags
            //this piece of code: inventory[0].transform.position = new Vector3((currentInventorySpot*45)-90+204,-90+114.75f,0);
            //is placing the images to pretty much random positions, which is why I added the 204 and 114.75f, but it's still doing it

            GameObject gameObject = hit.collider.gameObject;

            if (gameObject.CompareTag("keyWhite2A"))
            {
                hasKeyWhite2A = true;
                inventory[currentInventorySpot].GetComponent<Image>().sprite = images[0];
                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("keyWhite2B"))
            {
                hasKeyWhite2B = true;
                inventory[currentInventorySpot].GetComponent<Image>().sprite = images[1];
                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("square"))
            {
                hasSquare = true;

                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("triangle"))
            {
                hasTriangle = true;

                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("circle"))
            {
                hasCircle = true;

                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("keyWhite4"))
            {
                hasKeyWhite4 = true;

                currentInventorySpot += 1;
            }
            Destroy(gameObject);
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
