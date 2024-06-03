using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sdfs : MonoBehaviour
{
    public string nextStage;

    private void OnTriggerEnter2D(Collider2D other)

    {

        print("sdfs");
        if (other.CompareTag("Player")) // Check if the player enters the trigger
        {
            SceneManager.LoadScene(nextStage); // Load the specified scene
        }
    }
}
