using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitCodeScript : MonoBehaviour
{
    public string inputText;
    public GameObject reactionGroup;
    public string correctAnswer = "noescape";
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
