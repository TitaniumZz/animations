using System.Collections;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject BoxToOpen;
    public GameObject BoxToOpen2;
    public GameObject objectToDrag;
    public GameObject objectPlace;
    public float dropDistance;
    public float resetDelay = 2f;

    public GameObject[] nextObjectsToDrag;
    public GameObject[] nextObjectsPlace;

    private bool isLocked;
    private int step = 0;
    private Vector2 ObjectInitPos;

    void Start()
    {
        ObjectInitPos = objectToDrag.transform.position;
    }

    public void DragObject()
    {
        if (!isLocked)
        {
            objectToDrag.transform.position = Input.mousePosition;
        }
    }

    public void DropObject()
    {
        float distance = Vector3.Distance(objectToDrag.transform.position, objectPlace.transform.position);
        if (distance < dropDistance)
        {
            isLocked = true;
            objectToDrag.transform.position = objectPlace.transform.position;
            BoxToOpen.SetActive(true);
            BoxToOpen2.SetActive(true);
            StartCoroutine(ResetObjectsAfterDelay());
        }
        else
        {
            objectToDrag.transform.position = ObjectInitPos;
        }
    }

    private IEnumerator ResetObjectsAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay);

        // Destroy current objects
        Destroy(objectToDrag);
        Destroy(objectPlace);

        // Activate next objects to drag and place
        foreach (GameObject nextObject in nextObjectsToDrag)
        {
            nextObject.SetActive(true);
        }
        foreach (GameObject nextPlace in nextObjectsPlace)
        {
            nextPlace.SetActive(true);
        }
    }
}