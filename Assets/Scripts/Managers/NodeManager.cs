using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
    [SerializeField] NodeList _nodes;
    [SerializeField] SpriteRenderer _nodePrefab;
    [SerializeField] SpriteRenderer _nodeBackgroundPrefab;


    public static NodeManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void Start() => GenerateNodeList();

    private void GenerateNodeList()
    {
        float yPos = (float) GridManager.Instance.Height + 0.5f;
        for (int i = 0; i < _nodes.Elements.Length; i++)
        {
            var node = Instantiate(_nodePrefab, new Vector2(i, yPos) , Quaternion.identity);
            node.color = _nodes.Elements[i].Color;
        }

        Vector2 center = new Vector2((float) (_nodes.Elements.Length - 1) / 2 , yPos);
        var background = Instantiate(_nodeBackgroundPrefab, center, Quaternion.identity);
        background.size = new Vector2(_nodes.Elements.Length, 1);
    }
}
