using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameFieldFruitsData")]
public class GameFieldFruitsData : ScriptableObject
{
    public List<TileBase> FruitsTiles;
}

