using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public enum GameState
{
    Menu,
    Playing,
    Checking,
    GameOver
}
public class StateMachine : MonoBehaviour
{
    public static StateMachine Instance;
    public GameState m_GameState { get; private set; }
    [SerializeField] private int m_playerCount;
    [SerializeField] private GameObject m_menu;
    [SerializeField] private GameObject m_gameOver;
    [SerializeField] private PlayerController m_payerController;
    [SerializeField] private WinCondition m_winCondition;
    [SerializeField] private TMP_Text m_Winner;

    public int m_playerCounter { get; private set; }


    private void Awake()
    {
        Instance = this;
        m_playerCounter = 1;
    }

    public void ChangeState(GameState state)
    {
        m_GameState = state;
        switch (m_GameState)
        {

            case GameState.Menu:
                m_menu.SetActive(true);
                m_gameOver.SetActive(false);

                break;

            case GameState.Playing:
                if (m_playerCounter > m_playerCount) m_playerCounter = 1;
                m_playerCounter++;
                m_payerController.gameObject.SetActive(true);
                m_winCondition.gameObject.SetActive(false);

                break;

            case GameState.Checking:
                m_payerController.gameObject.SetActive(false);
                m_winCondition.gameObject.SetActive(true);
                int winner = m_winCondition.Check();
                if (winner != 0)
                { 
                    m_Winner.text = "Winner player - " + winner;
                }
                break;

            case GameState.GameOver:
                m_menu.SetActive(false);
                m_gameOver.SetActive(true);
                m_payerController.gameObject.SetActive(false);
                m_winCondition.gameObject.SetActive(false);
                break;

        }
    }

}
