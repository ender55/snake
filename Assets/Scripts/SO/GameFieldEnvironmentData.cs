using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameFieldEnvironmentData")]
public class GameFieldEnvironmentData : ScriptableObject
{
    public TileBase FloorTile;
    public TileBase WallTile;
}