using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header(" Sounds ")]
    [SerializeField] AudioSource doorHit;
    [SerializeField] AudioSource levelComplete;
    [SerializeField] AudioSource gameOver;
    [SerializeField] AudioSource runnerDie;

    private void Start()
    {
        Enemy.onRunnnerDied += PlayRunnerDieSound;
        PlayerDetection.onDoorsHit += PlayDoorHitSound;
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        Enemy.onRunnnerDied -= PlayRunnerDieSound;
        PlayerDetection.onDoorsHit -= PlayDoorHitSound;
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void PlayDoorHitSound()
    {
        doorHit.Play();
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Gameover)
            gameOver.Play();
        else if (gameState == GameManager.GameState.LevelComplete)
            levelComplete.Play();
    }

    public void PlayRunnerDieSound()
    {
        runnerDie.Play();
    }

    
}
