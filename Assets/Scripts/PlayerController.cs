using UnityEngine;




public enum GameState
{
    Menu,
    Playing,
    Checking,
    GameOver
}



public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera m_camera;
    [SerializeField] private float m_rayDistance = 100f;
    [SerializeField] private

    
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
                if (Input.GetMouseButtonDown(0))
                {
                        usable.SetSymbol(1);
                }
            }
        }
    }
}
