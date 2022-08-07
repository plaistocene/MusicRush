using System;
using UnityEngine;

public class LevelMovementManager : MonoBehaviour
{
    #region Variables

    public PlayerStats playerStats;

    #endregion

    #region Unity Methods

    private void Start()
    {
        playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (PlayerStats.IsGameStarted())
        {
            transform.Translate(Vector3.back * (playerStats.roadSpeed * Time.deltaTime));
        }
    }

    #endregion
}