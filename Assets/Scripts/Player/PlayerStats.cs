using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Variables

    private static PlayerStats _instance;

    public float roadSpeed;
    public float horizontalSpeed;
    private static bool _gameStarted;
    
    public float playerScale;
    public float groundScale;
    
    public float movementLimitX;


    #endregion

    #region Unity Methods

    private void Awake()
    {
        #region Singleton

        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        #endregion
    }
    #endregion

    public void CalculateMovementLimitX()
    {
        playerScale = GameObject.Find("Player").GetComponent<Transform>().localScale.x;
        groundScale = GameObject.Find("Ground").GetComponent<Transform>().localScale.x;

        movementLimitX = (groundScale * .5f) - (playerScale * .5f);
    }

    public static void StartGame()
    {
        _gameStarted = true;
    }

    public static bool IsGameStarted()
    {
        return _gameStarted;
    }

    public float GetRoadSpeed()
    {
        return roadSpeed;
    }

    public float GetHorizontalSpeed()
    {
        return horizontalSpeed;
    }

    public float GetMovementLimitX()
    {
        return movementLimitX;
    }
}