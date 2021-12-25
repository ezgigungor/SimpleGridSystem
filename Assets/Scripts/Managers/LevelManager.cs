using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public NodeList Nodes;
    public SpriteRenderer NodePrefab;

    [SerializeField] private List<GameObject> _nodes;

    public static LevelManager Instance { get; private set; }

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
        float yPos = (float)GridManager.Height / 2 + 1f;
        for (int i = 0; i < Nodes.Elements.Length; i++)
        {
            var node = Instantiate(NodePrefab, new Vector2(i, yPos) , Quaternion.identity);
            node.color = Nodes.Elements[i].Color;
        }
    }
}
