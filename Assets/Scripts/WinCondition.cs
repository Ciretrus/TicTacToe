using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private Cell[] cells;
    
    
    public void Check() 
    {
        
    }

    private void OnDisable()
    {
        foreach (var cell in cells)
        {
            cell.SetBase();
        }
    }

}
