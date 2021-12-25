using UnityEngine;

public class Draggable : MonoBehaviour
{

    private Camera _camera;
    private bool isDraggable = true;

    private void Start() => _camera = Camera.main;
    
    private void OnMouseDrag()
    {
        if (!isDraggable)
            return;

        if (GridManager.Instance.CheckIfInsideLevel(transform.position))
            transform.position = GetMousePosition();
    }

    private void OnMouseUp()
    {
        if (!isDraggable)
            return;
        
        transform.position = GridManager.Instance.GetNearestPointOnGrid(transform.position);
    }


    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}