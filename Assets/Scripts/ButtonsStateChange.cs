using UnityEngine;

public class ButtonsStateChange : MonoBehaviour
{
    public void Menu()
    {
        StateMachine.Instance.ChangeState(GameState.Playing);
    }
    public void GameOver()
    {
        StateMachine.Instance.ChangeState(GameState.Menu);
    }
}
