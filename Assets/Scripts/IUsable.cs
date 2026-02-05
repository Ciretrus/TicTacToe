using System;
using UnityEngine;
using UnityEngine.UIElements;
public struct CellAtribute
{
    public Vector2 position;
    public int player;
}


interface IUsable
{
    public CellAtribute SetSymbol(int player);
} 