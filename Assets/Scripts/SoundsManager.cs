using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [Header(" Sounds ")]
    [SerializeField] AudioSource button;
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

    public void DisableSounds()
    {
        doorHit.volume = 0;
        levelComplete.volume = 0;
        gameOver.volume = 0;
        runnerDie.volume = 0;
        button.volume = 0;
    }

    public void EnableSounds()
    {
        doorHit.volume = 1;
        levelComplete.volume = 1;
        gameOver.volume = 1;
        runnerDie.volume = 1;
        button.volume = 1;
    }
}
