using UnityEngine;

public class HideOnClick : MonoBehaviour
{
    private HidingJumping bushController;

    void Start()
    {
        bushController = GetComponentInParent<HidingJumping>();
    }

    void OnMouseDown()
    {
        bushController.OnChildClicked();
    }
}