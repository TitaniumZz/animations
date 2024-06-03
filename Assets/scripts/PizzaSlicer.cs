using UnityEngine;

public class PizzaSlicer : MonoBehaviour
{
    public GameObject knife;
    public GameObject[] pizzaSlices; // Array to hold slice prefabs
    private LineRenderer lineRenderer;
    private bool isSlicing = false;
    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        lineRenderer = knife.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        HandleSlicing();
    }

    void HandleSlicing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSlicing = true;
            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPosition.z = 0;
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, startPosition);
        }
        else if (Input.GetMouseButtonUp(0) && isSlicing)
        {
            isSlicing = false;
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPosition.z = 0;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(1, endPosition);
            SlicePizza();
        }
    }

    void SlicePizza()
    {
        // Example slicing logic, assuming 8 slices
        int sliceCount = pizzaSlices.Length;
        float angleIncrement = 360f / sliceCount;
        Vector3 center = transform.position;

        // Instantiate slices around the center
        for (int i = 0; i < sliceCount; i++)
        {
            GameObject slice = Instantiate(pizzaSlices[i], center, Quaternion.identity);
            slice.transform.RotateAround(center, Vector3.forward, i * angleIncrement);
            slice.transform.parent = transform;
        }

        // Hide or destroy the original pizza object
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
