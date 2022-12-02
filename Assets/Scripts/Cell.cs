using UnityEngine;

public class Cell: IStatable
{
    public StateMachine StateMachine { get; }

    public Cell(CellState state)
    {
        StateMachine = new StateMachine();
        StateMachine.SetState(state);
    }
}