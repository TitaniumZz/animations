using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPlacer : MonoBehaviour
{
    private int objectsPlaced = 0;

    void OnEnable()
    {
        Debug.Log("ObjectPlacer enabled");
        DragAndDropUtility.Contains<GameObject>(); // Initialize the drag-and-drop utility
    }

    void Update()
    {
        if (DragAndDropUtility.Contains<GameObject>() && DragAndDropUtility.Is<GameObject>())
        {
            // An object has been dropped
            objectsPlaced++;
            Debug.Log("Object dropped. objectsPlaced: " + objectsPlaced);

            if (objectsPlaced == 9)
            {
                Debug.Log("Loading next scene...");
                SceneManager.LoadScene(2);
            }
        }
    }

    void LoadNextScene()
    {
        Debug.Log("Loading next scene...");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      
        SceneManager.LoadScene(2);
    }
}