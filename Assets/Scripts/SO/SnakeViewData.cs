using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Snake", menuName = "ScriptableObjects/SnakeViewData")]
public class SnakeViewData : ScriptableObject
{
    public Sprite HeadTile;
    public Sprite StraightBodyTile;
    public Sprite AngleRBodyTile;
    public Sprite AngleLBodyTile;
    public Sprite TailTile;
}