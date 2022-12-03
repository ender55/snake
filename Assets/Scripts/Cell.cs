using System;
using UnityEngine;

public class Cell
{
    public enum States
    {
        Empty,
        Wall,
        Food
    }

    public States CurrentState = States.Empty;
}