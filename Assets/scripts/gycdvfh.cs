using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gycdvfh : MonoBehaviour
{
    int runspeed = 5;
    int jumpforce = 5;
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("Walking", true);
            GetComponent<Animator>().SetBool("Idle", false);
            transform.Translate(Vector3.right*Time.deltaTime*runspeed);

        }
        if (Input.GetKey(KeyCode.S))
        {

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("Jump");
            GetComponent<Rigidbody>().AddForce(Vector2.up * jumpforce);

        }
        if (!Input.anyKey)
        {
            GetComponent<Animator>().SetBool("Walking", false);
            GetComponent<Animator>().SetBool("Idle", true);
        }
    }

}
