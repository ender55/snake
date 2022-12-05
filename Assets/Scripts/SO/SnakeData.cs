using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Snake", menuName = "ScriptableObjects/SnakeData")]
public class SnakeData : ScriptableObject
{
    public int size;
    public Sprite HeadTile;
    public Sprite StraightBodyTile;
    public Sprite AngleRBodyTile;
    public Sprite AngleLBodyTile;
    public Sprite TailTile;
}