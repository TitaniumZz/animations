using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingJumping : MonoBehaviour
{
    public Transform[] children; // Assign the 5 child objects in the Inspector
    private int currentIndex = 0;
    private bool isChildVisible = false;

    void Start()
    {
        // Initialize all children to be hidden
        foreach (Transform child in children)
        {
            child.localPosition = new Vector3(child.localPosition.x, -2, child.localPosition.z);
        }

        // Start the coroutine to make the children appear one by one
        StartCoroutine(MakeChildrenAppear());
    }

    IEnumerator MakeChildrenAppear()
    {
        while (true)
        {
            // Wait for a random amount of time before making the next child appear
            yield return new WaitForSeconds(Random.Range(1f, 3f));

            // Make the next child appear
            MakeChildAppear();
        }
    }

    void MakeChildAppear()
    {
        // Get the next child in the array
        Transform child = children[currentIndex];

        // Move the child up to its original position
        child.DOLocalMoveY(0, 0.5f);

        // Set a flag to indicate that a child is visible
        isChildVisible = true;

        // Increment the index for the next child
        currentIndex = (currentIndex + 1) % children.Length;
    }

    public void OnChildClicked()
    {
        // If a child is visible, hide it and reset the flag
        if (isChildVisible)
        {
            int lastIndex = currentIndex - 1;
            if (lastIndex < 0)
            {
                lastIndex = children.Length - 1;
            }
            Transform child = children[lastIndex];
            child.gameObject.SetActive(false);
            isChildVisible = false;
        }
    }
}