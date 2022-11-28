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
    }

    private void OnDestroy()
    {
        Enemy.onRunnnerDied -= PlayRunnerDieSound;
    }

    public void PlayDoorHitSound()
    {
        doorHit.Play();
    }

    public void PlayLevelCompleteSound()
    {
        levelComplete.Play();
    }

    public void PlayGameOverSound()
    {
        gameOver.Play();
    }

    public void PlayRunnerDieSound()
    {
        runnerDie.Play();
    }

    
}
