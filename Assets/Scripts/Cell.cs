using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Cell : MonoBehaviour,IUsable
{
    public Vector2 m_Position { get; private set; }
    private Renderer m_renderer;
    [SerializeField] private GameObject[] m_figures;
    [SerializeField] private Vector3 m_offset;
    [SerializeField] private Color[] m_colors;
    [SerializeField] private Color m_baseColor;
    [SerializeField] private Vector2 m_position;
    private GameObject m_child;
    private bool m_isUsed; 
    public bool IsUsed { get { return m_isUsed; } }
    void Awake()
    {   

        m_isUsed = false;
        m_Position = m_position;
    }
    public CellAtribute SetSymbol(int player)
    {
        m_isUsed = true;
        
        CellAtribute cellAtribute = new CellAtribute();
        cellAtribute.position = m_position;
        cellAtribute.player = player;
        m_child = Instantiate(m_figures[player-1],transform.position+m_offset,transform.rotation);
        m_renderer = m_child.GetComponent<Renderer>();
        m_renderer.material.color = m_colors[player-1];

        Debug.Log($"cell {m_position} player {player}");

        return cellAtribute;
    }

    public void SetBase()
    {   
        if (m_child != null) Destroy(m_child);
        m_isUsed = false;
    }

}
