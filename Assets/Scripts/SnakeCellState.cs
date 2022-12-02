public class SnakeCellState : CellState
{
    public SnakeCellState(Cell cell) : base(cell)
    {
    }
    
    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        //todo: вернуть клетку в стандартное состояние
    }
}