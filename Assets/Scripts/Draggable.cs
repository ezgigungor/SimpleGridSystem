using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _lastPosition;


    private void Start()
    {
        _camera = Camera.main;
        _lastPosition = transform.position;
    }
    
    private void OnMouseDrag() => transform.position = GetMousePosition();
    

    private void OnMouseUp()
    {   
        if (GridManager.Instance.IsInsideGrid(transform.position))
        {
            transform.position = GridManager.Instance.GetNearestPointOnGrid(transform.position);
            _lastPosition = transform.position;
        }
        else
        {
            transform.position = _lastPosition;
        }
    }


    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f; // Grids distance to camera
        mousePos = _camera.ScreenToWorldPoint(mousePos);
        return mousePos;
    }
}