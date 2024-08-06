using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//put this script on any item that should be picked up

public class PickupScript : MonoBehaviour
{
    public static PickupScript instance;
    public int currentInventorySpot = 0;
    public bool hasKeyWhite2A = false;
    public bool hasKeyWhite2B = false;
    public bool hasSquare = false;
    public bool hasTriangle = false;
    public bool hasCircle = false;
    public bool hasKeyWhite4 = false;
    public float equipped;
    public Texture2D hoveringCursorTexture;
    public Texture2D cursorTexture;

    public List<GameObject> inventory;
    void Start()
    {
        instance = this;  
    }

    private void OnMouseDown(){
        if(currentInventorySpot < 5){
            //add ui raw images with picutres of the other pickupable objects and move them to the inventory list
            //give the pickupable objects the following tags
            //this piece of code: inventory[0].transform.position = new Vector3((currentInventorySpot*45)-90+204,-90+114.75f,0);
            //is placing the images to pretty much random positions, which is why I added the 204 and 114.75f, but it's still doing it

            if (gameObject.CompareTag("keyWhite2A")){
                hasKeyWhite2A = true;
                inventory[0].SetActive(true);
                inventory[0].transform.position = new Vector3((currentInventorySpot*45)+272.5f-90,153-90,0);
                print("inventory[0].transform.position.x"+inventory[0].transform.position.x);
                print("currentInventorySpot"+currentInventorySpot);
                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("keyWhite2B")){
                hasKeyWhite2B = true;
                inventory[1].SetActive(true);
                inventory[1].transform.position = new Vector3((currentInventorySpot*45)-90+204,-90+114.75f,0);
                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("square")){
                hasSquare = true;
                inventory[2].SetActive(true);
                inventory[2].transform.position = new Vector3((currentInventorySpot*45)-90+204,-90+114.75f,0);
                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("triangle")){
                hasTriangle = true;
                inventory[3].SetActive(true);
                inventory[3].transform.position = new Vector3((currentInventorySpot*45)-90+204,-90+114.75f,0);
                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("circle")){
                hasCircle = true;
                inventory[4].SetActive(true);
                inventory[4].transform.position = new Vector3((currentInventorySpot*45)-90+204,-90+114.75f,0);
                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("keyWhite4")){
                hasKeyWhite4 = true;
                inventory[5].SetActive(true);
                inventory[5].transform.position = new Vector3((currentInventorySpot*45)-90+204,-90+114.75f,0);
                currentInventorySpot += 1;
            }
            Destroy(gameObject);
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto); 
        }
    }
    void OnMouseOver(){
        Cursor.SetCursor(hoveringCursorTexture, Vector2.zero, CursorMode.Auto); 
    }
    void OnMouseExit(){
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto); 
    }
    void Update()
    {
        //this is for when they need to use the object they press the corresponding number to the place in the inventory, though it still needs some work
        if(Input.GetKeyDown("1")){
            equipped = 1;
        }

    }
}
