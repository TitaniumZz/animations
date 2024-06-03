
using UnityEngine;

public class SlidingPuzzleScript : MonoBehaviour
{
  
    [SerializeField] private GameObject emptySpace;
    private Camera _camera;

    void Start()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _camera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray  = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);
        if (hit)
        {
            Debug.Log(hit.transform.name);
        }
    }
}
