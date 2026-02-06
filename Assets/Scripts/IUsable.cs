using UnityEngine;
public struct CellAtribute
{
    public Vector2 position;
    public int player;
}


interface IUsable
{
    public CellAtribute SetSymbol(int player);
    public bool IsUsed {  get; }
} 