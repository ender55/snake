using UnityEngine;

public interface IMovementInputController
{
    public PlayerKeyCodes PlayerKeyCodes { get; set; }
    public Vector3Int Direction { get; set; }
    
    public Vector3Int HandleInput();
}