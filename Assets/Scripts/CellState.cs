public abstract class CellState : IState
{
    protected Cell cell;

    protected CellState(Cell cell)
    {
        this.cell = cell;
    }
    
    public StateMachine StateMachine { get; set; }

    public abstract void Enter();
    
    public abstract void Exit();
}