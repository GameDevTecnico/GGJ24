using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riddle : MonoBehaviour
{
    private string currentString = "";
    private List<string> wordList = new List<string> { "word1", "word2", "word3", "word4", "word5" };

    public void WriteChar(string letter)
    {
        currentString += letter;
        Debug.Log("Current String: " + currentString);

        if (currentString.Length > 5)
        {
            Delete();
        }

        CheckWord();
    }

    public void Delete()
    {
        currentString = "";
    }

    private void CheckWord()
    {
        if (wordList.Contains(currentString))
        {
            Debug.Log("Valid word found: " + currentString);
        }
    }
}
