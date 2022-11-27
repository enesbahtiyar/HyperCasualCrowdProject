using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] Text LevelText;
    [SerializeField] Slider progressBar;

    private void Start()
    {
        progressBar.value = 0;
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(false);
        levelCompletePanel.SetActive(false);
        LevelText.text = "Level " + (ChunkManager.instance.GetLevel() + 1);

        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void Update()
    {
        UpdateProgressBar();
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.Gameover)
        {
            ShowGameOverPanel();
        }
        else if(gameState == GameManager.GameState.LevelComplete)
        {
            ShowLevelCompletePanel();
        }
    }

    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.Game);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void RetryButtonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowGameOverPanel()
    {
        gamePanel.SetActive(false);
        gameoverPanel.SetActive(true);
    }

    public void UpdateProgressBar()
    {
        if (!GameManager.instance.IsGameState()) { return; }

        float progress = PlayerController.instance.transform.position.z / ChunkManager.instance.GetFinishZ();
        progressBar.value = progress;
    }

    private void ShowLevelCompletePanel()
    {
        gamePanel.SetActive(false);
        levelCompletePanel.SetActive(true);
    }
}
