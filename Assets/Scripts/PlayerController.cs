using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;

    [Header(" Elements ")]
    [SerializeField] CrowdSystem crowdSystem;
    [SerializeField] PlayerAnimator playerAnimator;

    [Header(" Settings ")]
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float roadWidth = 10f;
    bool canMove = false;


    [Header(" Control ")]
    [SerializeField] float slideSpeed;
    private Vector3 clickedScreenPosition;
    private Vector3 clickedPlayerPosition;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }


    void Update()
    {
        if (canMove)
        {
            MoveForward();

            ManageControl();
        }
    }

    private void GameStateChangedCallback(GameManager.GameState gameState)
    {
        if (gameState == GameManager.GameState.Game)
        {
            StartMoving();
        }
        else if (gameState == GameManager.GameState.Gameover || gameState == GameManager.GameState.LevelComplete)
            moveSpeed = 0;
    }

    private void StartMoving()
    {
        canMove = true;

        playerAnimator.Run();
    }

    private void StopMoving()
    {
        canMove = false;

        playerAnimator.Idle();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickedScreenPosition = Input.mousePosition;
            clickedPlayerPosition = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickedScreenPosition.x;

            xScreenDifference /= Screen.width;
            xScreenDifference *= slideSpeed;

            Vector3 position = transform.position;
            position.x = clickedPlayerPosition.x + xScreenDifference;

            position.x = Mathf.Clamp(position.x, -roadWidth / 2 + crowdSystem.GetCrowdRadious(),
                roadWidth / 2 - crowdSystem.GetCrowdRadious());

            transform.position = position;

            //transform.position = clickedPlayerPosition + Vector3.right * xScreenDifference;
        }
    }
}
