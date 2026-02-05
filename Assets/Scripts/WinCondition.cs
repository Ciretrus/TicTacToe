using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class WinCondition : MonoBehaviour
{  
    
    [SerializeField] private Cell[] m_cells;
    [SerializeField] private int m_cellGrid = 3;
    private int m_moveCounter;
    public bool isMovesEnd { get { return m_moveCounter == m_cellGrid * m_cellGrid; }}
    private int[,] m_cellConditions;
    

    private void Awake()
    {
        m_cellConditions = new int[m_cellGrid, m_cellGrid];
    }
    public int Check() 
    {
        int winPlayer = 0;
        for (int x = 0; x < m_cellGrid; x++)
        {   
            int lineIDPlayer = m_cellConditions[x,0];
            winPlayer = lineIDPlayer;
            for (int y = 0; y < m_cellGrid; y++)
            {
                if (lineIDPlayer != m_cellConditions[x, y] || lineIDPlayer == 0)
                {
                    winPlayer = 0;
                    break;
                }
            }
                
        }

        for (int y = 0; y < m_cellGrid; y++)
        {
            int lineIDPlayer = m_cellConditions[0, y];
            winPlayer = lineIDPlayer;
            for (int x = 0; x < m_cellGrid; x++)
            {
                if (lineIDPlayer != m_cellConditions[x, y] || lineIDPlayer == 0)
                {
                    winPlayer = 0;
                    break;
                }
            }

        }

        for (int i = 0; i < m_cellGrid; i++)
        {
            int lineIDPlayer = m_cellConditions[0, 0];
            winPlayer = lineIDPlayer;
            if (lineIDPlayer != m_cellConditions[i, i] || lineIDPlayer == 0)
            {
                winPlayer = 0;
                break;
            }

        }

        for (int i = 0; i < m_cellGrid; i++)
        {
            int lineIDPlayer = m_cellConditions[i, 0];
            winPlayer = lineIDPlayer;
            if (lineIDPlayer != m_cellConditions[m_cellGrid-i, i] || lineIDPlayer == 0)
            {
                winPlayer = 0;
                break;
            }

        }

        return winPlayer;
    }

    private void OnDisable()
    {
        foreach (var cell in m_cells)
        {
            cell.SetBase();
        }
        for (int i = 0;i < m_cellGrid; i++)
        {
            for (int j = 0; j < m_cellGrid; j++)
            {
                m_cellConditions[i, j] = 0;
            }
        }
        m_moveCounter = 0;
    }
    public void AddUsedCell(CellAtribute cell)
    {
        int x = (int)cell.position.x;
        int y = (int)cell.position.y;
        m_cellConditions[x, y] = cell.player;
        m_moveCounter++;

    }

}
