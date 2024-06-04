using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Succeed : MonoBehaviour
{
    public GameObject SucceedCanvas;
    // Start is called before the first frame update
    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            SucceedCanvas.SetActive(true);  
        }
    }
}
