using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

public class Cell : MonoBehaviour,IUsable
{
    public Vector2 m_Position { get; private set; }
    private Renderer m_renderer;
    [SerializeField] private Color[] m_colors;
    [SerializeField] private Color m_baseColor;
    [SerializeField] private Vector2 m_position;

    void Awake()
    {
        m_Position = m_position;
        m_renderer = GetComponent<Renderer>();
    }
    public CellAtribute SetSymbol(int player)
    {   
        CellAtribute cellAtribute = new CellAtribute();
        cellAtribute.position = m_position;
        cellAtribute.player = player;

        m_renderer.material.color = m_colors[player];

        Debug.Log($"cell {m_position} player {player}");

        return cellAtribute;
    }

    public void SetBase()
    {
        m_renderer.material.color = m_baseColor;
    }

}
