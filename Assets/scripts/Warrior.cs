using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    public int speed = 10;
    public bool playerTwo;
    public Animator walker;

    private void Start()
    {
         void Start()
        {
            walker = GetComponent<Animator>();
        }

    }

    void Update()
    {
         if (Input.GetKey(KeyCode.A) && playerTwo)
        {
            GetComponent<Animator>().SetBool("Walk", true);
            GetComponent<Animator>().SetBool("Idle", false);
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            if (walker != null)
            {
                walker.SetBool("Walking", true);
            }
        }
        else
        {
            if (walker != null)
            {
                walker.SetBool("Walking", false);
                walker.SetBool("Idle", true);
            }
        }

        if (Input.GetKey(KeyCode.D) && playerTwo)
        {
            GetComponent<Animator>().SetBool("Walk",true);
            GetComponent<Animator>().SetBool("Idle", false);
            transform.Translate(Vector2.right * Time.deltaTime * speed);
            if (walker != null)
            {
                walker.SetBool("Walking", true);
            }
        }
        else
        {
            if (walker != null)
            {
                walker.SetBool("Walking", false);
                walker.SetBool("Idle", true);
            }
        }
        if (!Input.anyKey)
        {

            GetComponent<Animator>().SetBool("Walk", false);
            GetComponent<Animator>().SetBool("Idle", true);
        }
    }
}
