using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComputerPasswordScript : MonoBehaviour
{
    public string inputText;
    public GameObject reactionGroup;
    public string correctAnswer;
    public GameObject passwordText;

    void Start()
    {
        if(gameObject.CompareTag("2bcode")){
            correctAnswer = "unity";
        }
        else if(gameObject.CompareTag("3code")){
            correctAnswer = "noescape";
        }
    }

    public void GrabFromInputField (string input)
    {
        inputText = input;
        if (inputText == correctAnswer)
        {
            DisplayReactionToInput();
        }
        else if (inputText == "password")
        {
            passwordText.GetComponent<TMP_Text>().text = "C'mon really?!";
        }
    }
    private void DisplayReactionToInput()
    {
        reactionGroup.SetActive(true);
        gameObject.SetActive(false);
        passwordText.SetActive(false);
        if(gameObject.CompareTag("3code")){
            GameManager.instance.EndGame();
        }
    }
}
