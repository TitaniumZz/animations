using DG.Tweening;
using System.Collections;
using UnityEngine;

public class HidingJumping : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(CrouchAndReveal());
    }

    IEnumerator CrouchAndReveal()
    {
        while (true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                float y = child.localPosition.y;

                foreach (Transform sibling in transform)
                {
                    if (sibling != child)
                    {
                        sibling.DOLocalMoveY(sibling.localPosition.y - 2, 0.5f);
                    }
                }

               
                child.DOLocalMoveY(y - 2, 0.5f);
                yield return new WaitForSeconds(1.5f);
                child.DOLocalMoveY(y, 0.5f);

                if (child.GetComponent<HideOnClick>() == null)
                {
                    child.gameObject.AddComponent<HideOnClick>();
                }

                yield return new WaitForSeconds(1.5f);
            }
        }
    }
}
