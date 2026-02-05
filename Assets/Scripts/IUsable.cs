using System;
using UnityEngine;
using UnityEngine.UIElements;
public struct Cell
{
    public Vector2 position;
    public int player;
}

interface IUsable
{
    void SetSymbol(Cell cell);
} 