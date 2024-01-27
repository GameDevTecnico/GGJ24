using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharFinish : MonoBehaviour
{
    [SerializeField] private CharCreator charCreator;

    public void LoadNextScene()
    {
        if (charCreator != null)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.head = charCreator.head;
                gameManager.leg = charCreator.leg;
                gameManager.torso = charCreator.torso;
            }
        }
        SceneManager.LoadScene("Lvl 2");
    }
}
