using UnityEngine;

public class Cell : MonoBehaviour,IUsable
{
    public Vector2 m_position;
    private Renderer m_renderer;
    [SerializeField] private Color[] m_colors;
    [SerializeField] private Color m_baseColor;
    void Awake()
    {
        m_renderer = GetComponent<Renderer>();
    }
    public CellAtribute SetSymbol(int player)
    {   CellAtribute cellAtribute = new CellAtribute();
        cellAtribute.position = m_position;
        cellAtribute.player = player;
        m_renderer.material.color = m_colors[player];
        Debug.Log($"cell {m_position} player {player}");
        return cellAtribute;
    }

}
