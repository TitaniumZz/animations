using UnityEngine;
using System.Collections;
public class TopAtma : MonoBehaviour
{
    public Rigidbody2D topRigidbody;
    public float yukariKuvvet = 10f;
    public float sagaHiz = 5f;
    public float yukariKuvvet2 = 10f;
    public float sagaHiz2 = 5f;
    private bool tusaBasildi = false;
    private Vector3 eskiKonum;

    void Start()
    {
        eskiKonum = transform.position; // Ba�lang��ta topun eski konumunu sakla
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1) && !tusaBasildi)
        {
            topRigidbody.velocity = Vector2.zero;
            topRigidbody.AddForce(Vector2.up * yukariKuvvet, ForceMode2D.Impulse);
            topRigidbody.AddForce(Vector2.left * sagaHiz, ForceMode2D.Impulse);
            tusaBasildi = true;
            StartCoroutine(ReturnToHandAfterDelay(5f)); // 5 saniye sonra geri d�n
        }

        if (Input.GetKeyUp(KeyCode.Alpha2) && !tusaBasildi)
        {
            topRigidbody.velocity = Vector2.zero;
            topRigidbody.AddForce(Vector2.up * yukariKuvvet2, ForceMode2D.Impulse);
            topRigidbody.AddForce(Vector2.left * sagaHiz2, ForceMode2D.Impulse);
            tusaBasildi = true;
            StartCoroutine(ReturnToHandAfterDelay(5f)); // 5 saniye sonra geri d�n
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left * 5f;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right * 5f;
        }
    }

    private IEnumerator ReturnToHandAfterDelay(float delay)
    {
        yield return new WaitForSeconds(3); // Belirtilen s�re kadar bekle
        transform.position = eskiKonum; // Obje eski konumuna geri gelsin
        tusaBasildi = false; // Tu� bas�ld� durumunu resetle
        topRigidbody.velocity = Vector2.zero; // Rigidbody h�z�n� s�f�rla
    }
}