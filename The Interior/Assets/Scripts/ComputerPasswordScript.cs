using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComputerPasswordScript : MonoBehaviour
{
    private string inputText;
    private GameObject reactionGroup;
    private string correctAnswer = "UNITY";
    public GameObject passwordText;

    public void GrabFromInputField (string input)
    {
        inputText = input;
        if (inputText == correctAnswer)
        {
            DisplayReactionToInput();
        }
    }
    private void DisplayReactionToInput()
    {
        reactionGroup.SetActive(true);
        gameObject.SetActive(false);
        passwordText.SetActive(false);
    }
}
