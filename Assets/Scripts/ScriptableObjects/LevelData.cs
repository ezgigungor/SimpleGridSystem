using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "GridSystem/Level")]
public class LevelData : ScriptableObject
{
    public List<Node> Nodes;
}
