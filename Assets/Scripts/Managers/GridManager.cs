using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField] private int _width = 5;
    [SerializeField] private int _height = 5;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private SpriteRenderer _gridBackgroundPrefab;

    private Transform _cameraTransform;
    public static GridManager Instance { get; private set; }
    public int Height { get => _height; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        CreateGrid();
    }


    private void CreateGrid()
    {
        for (int i = 0; i < _width; i++)
            for (int j = 0; j < _height; j++)
                Instantiate(_tilePrefab, new Vector2(i, j), Quaternion.identity);

        Vector2 gridCenter = new Vector2((float)(_width - 1) / 2, (float)(_height - 1) / 2);
        var gridBackground = Instantiate(_gridBackgroundPrefab, gridCenter , Quaternion.identity);
        gridBackground.size = new Vector2(_width, _height);
        _cameraTransform.Translate(gridCenter);
    }

    public Vector3 GetNearestPointOnGrid(Vector3 pos)
    {
        Vector3 newPos = new Vector3(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y), 0);
        return newPos;
    }


    public bool IsInsideGrid(Vector3 pos)
    {
        return pos.x > - 0.5f && pos.x < (float) _width - 0.5f && pos.y > - 0.5f && pos.y < (float) _height - 0.5f;
    }
}
