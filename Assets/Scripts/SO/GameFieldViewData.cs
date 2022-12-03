using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameFieldEnvironmentData")]
public class GameFieldViewData : ScriptableObject
{
    public TileBase FloorTile;
    public TileBase WallTile;
    public List<TileBase> FruitTiles;
}