using UnityEngine;

public class Draggable : MonoBehaviour
{

    private Camera _camera;
    private bool isDraggable = true;

    private void Start() => _camera = Camera.main;
    
    private void OnMouseDrag()
    {
        print(transform.position);
        if (!isDraggable)
            return;

        transform.position = GetMousePosition();
    }

    private void OnMouseUp()
    {
        if (!isDraggable)
            return;

        if (GridManager.Instance.IsInsideGrid(transform.position))
            transform.position = GridManager.Instance.GetNearestPointOnGrid(transform.position);
    }


    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Debug.DrawRay(_camera.transform.position, mousePos);
        mousePos.z = 0;
        return mousePos;
    }
}