using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Password : MonoBehaviour
{
    [SerializeField] private GameObject passBox;
    private bool opened;
    private bool passBoxActive;
    private void Update()
     
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (opened)
            {
                if (!passBoxActive && passBox != null)
                {
                    passBox.SetActive(true);
                    passBoxActive = true;
                }
                else if (passBoxActive)
                {
                    passBox.SetActive(false);
                    passBoxActive = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            opened = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            opened = false;
        }
    }
}