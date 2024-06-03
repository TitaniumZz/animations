using DG.Tweening;
using System.Collections;
using UnityEngine;

public class HideOnClick : MonoBehaviour
{
    private bool isHidden = false;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void OnMouseDown()
    {
        if (!isHidden)
        {
            isHidden = true;
            // Move the child out of view
            transform.DOLocalMoveY(originalPosition.y - 2, 0.5f).OnComplete(() =>
            {
                // Delay and then move back to the original position
                StartCoroutine(RevealAfterDelay());
            });
        }
    }

    private IEnumerator RevealAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        transform.DOLocalMoveY(originalPosition.y, 0.5f).OnComplete(() =>
        {
            isHidden = false;
        });
    }
}
