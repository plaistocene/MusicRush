using System;
using UnityEngine;

public class PlayerForwardMovement : MonoBehaviour
{
    #region Variables

    public PlayerVelocityController playerVelocityController;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    private void Start()
    {
        playerVelocityController = GetComponent<PlayerVelocityController>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playerVelocityController.MoveForward(Time.fixedDeltaTime);
    }

    #endregion
}
