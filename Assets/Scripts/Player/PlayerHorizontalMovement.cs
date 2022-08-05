using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    #region Variables

    public PlayerVelocityController playerVelocityController;
    public bool right;
    public bool left;

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
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
    }

    private void FixedUpdate()
    {
        if (right)
        {
            right = false;
            playerVelocityController.MoveRight(Time.fixedDeltaTime);
        }

        if (left)
        {
            left = false;
            playerVelocityController.MoveLeft(Time.fixedDeltaTime);
        }
    }

    #endregion
}