using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private float m_rayDistance = 100f;
    [SerializeField] private WinCondition m_winCondition;
    


    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*m_rayDistance);
        Physics.Raycast(ray, out hit, m_rayDistance);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent(out IUsable usable))
            {
                if (Input.GetMouseButtonDown(0) && StateMachine.Instance.m_GameState == GameState.Playing )
                {
                    if (!usable.IsUsed)
                    {
                        var cell = usable.SetSymbol(StateMachine.Instance.m_playerCounter);
                        m_winCondition.AddUsedCell(cell);
                        StateMachine.Instance.ChangeState(GameState.Checking);
                    }
                }
            }
        }
    }

}
