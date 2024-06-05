using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image image1;
    public Image image2;
    public KeyCode toggleKey = KeyCode.Space;

    void Start()
    {
  
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(true);
    }

    void Update()
    {
      
        if (Input.GetKeyDown(toggleKey))
        {
            bool isActive = image1.gameObject.activeSelf;
            image1.gameObject.SetActive(!isActive);
            image2.gameObject.SetActive(!isActive);
        }
    }
}
