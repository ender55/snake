using System;
using UnityEngine;

public class FoodCellState : CellState
{
    //public event Action OnFoodEnter;
    //public event Action OnFoodExit;
    public FoodCellState(Cell cell) : base(cell)
    {
    }

    public override void Enter()
    {
        //OnFoodEnter?.Invoke();
    }

    public override void Exit()
    {
        //OnFoodExit?.Invoke();
    }
}