using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera mainCamera; // Reference to the main camera
    public float knifeZPosition = 0f; // Z position to keep the knife at the correct depth

    void Start()
    {
        // Ensure the mainCamera is assigned
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        MoveKnife();
    }

    void MoveKnife()
    {
        if (mainCamera != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.forward, new Vector3(0, 0, knifeZPosition));
            float distance;

            if (plane.Raycast(ray, out distance))
            {
                Vector3 targetPosition = ray.GetPoint(distance);
                transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            Debug.LogError("Main Camera is not assigned in the KnifeController script.");
        }
    }
}
