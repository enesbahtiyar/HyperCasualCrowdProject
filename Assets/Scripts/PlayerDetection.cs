using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] CrowdSystem crowdSystem;
    [SerializeField] PlayerAnimator playerAnim;
    [SerializeField] SoundsManager soundsManager;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.IsGameState())
        {
            DetectDoors();
        }
    }

    private void DetectDoors()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, 1);

        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Doors doors))
            {
                Debug.Log("we hit some doors");

                int bonusAmount = doors.GetBonusAmount(transform.position.x);
                BonusType bonusType = doors.GetBonusType(transform.position.x);

                doors.Disable();

                soundsManager.PlayDoorHitSound();

                crowdSystem.ApplyBonus(bonusType, bonusAmount);
            }
            else if (detectedColliders[i].tag == "Finish")
            {

                Debug.Log("Finish Line");

                PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);

                GameManager.instance.SetGameState(GameManager.GameState.LevelComplete);

                soundsManager.PlayLevelCompleteSound();

                playerAnim.Idle();

                //SceneManager.LoadScene(0);
            }

        }
    }


}
