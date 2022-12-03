using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SnakeData")]
public class SnakeViewData : ScriptableObject
{
    public TileBase HeadTile;
    public TileBase StraightBodyTile;
    public TileBase AngleBodyTile;
    //public TileBase SecondAngleBodyTile;
    public TileBase TailTile;
}