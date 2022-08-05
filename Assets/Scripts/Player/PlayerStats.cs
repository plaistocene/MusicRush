using System;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Variables

    private static PlayerStats _instance;

    public float forwardSpeed;
    public float horizontalSpeed;

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
}