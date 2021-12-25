using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width = 5;
    [SerializeField] private int _height = 5;
    private Tile _tilePrefab;

    private void CreateGrid()
    {
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; i < _height; j++)
            {
                var tile = Instantiate(_tilePrefab, new Vector2(i, j), Quaternion.identity);
            }
        }
            
    }
}
