using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    // Start is called before the first frame update
    void Start()
    {
        instance = this;  
    }
    private void OnMouseDown(){
        if(currentInventorySpot < 5){
            if (gameObject.CompareTag("keyWhite2A")){
                hasKeyWhite2A = true;
                inventory[0].SetActive(true);
                inventory[0].transform.position = new Vector3(inventory[0].transform.position.x + (currentInventorySpot*45),0,0);
                currentInventorySpot += 1;
            }
            else if (gameObject.CompareTag("keyWhite2B")){
                hasKeyWhite2B = true;
            }
            else if (gameObject.CompareTag("square")){
                hasSquare = true;
            }
            else if (gameObject.CompareTag("triangle")){
                hasTriangle = true;
            }
            else if (gameObject.CompareTag("circle")){
                hasCircle = true;
            }
            else if (gameObject.CompareTag("keyWhite4")){
                hasKeyWhite4 = true;
            }
            Destroy(gameObject);
        }
    }
    void OnMouseOver(){
        Cursor.SetCursor(hoveringCursorTexture, Vector2.zero, CursorMode.Auto); 
    }
    void OnMouseExit(){
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto); 
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")){
            equipped = 1;
        }

    }
}
