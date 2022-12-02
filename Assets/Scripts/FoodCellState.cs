public class FoodCellState : CellState
{
    public FoodCellState(Cell cell) : base(cell)
    {
    }

    public override void Enter()
    {
        //todo: отрисовать фрукт или сделать отрисовку в отдельном месте
    }

    public override void Exit()
    {
        //todo: заспавнить новый фрукт или прокинуть ивент
    }
}