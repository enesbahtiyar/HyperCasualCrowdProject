using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerDetection.onDoorsHit += Vibrate;
        Enemy.onRunnnerDied += Vibrate;
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        PlayerDetection.onDoorsHit -= Vibrate;
        Enemy.onRunnnerDied -= Vibrate;
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.LevelComplete)
            Vibrate();
        if (gameState == GameManager.GameState.Gameover)
            Vibrate();
    }

    private void Vibrate()
    {
        Taptic.Light();
    }
}
