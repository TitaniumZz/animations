using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intropass : MonoBehaviour
{
    public float duration = 2f;
    public string nextStage;
    private float currentTime = 0f;
    private bool isIncreasing = true;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > duration)
        {
       
            SceneManager.LoadScene(1); // Load the specified scene
        }
    }
}
