using UnityEngine;

public class PlayerVelocityController : MonoBehaviour
{
    #region Variables

    public PlayerStats playerStats;
    public Rigidbody playerRigidbody;

    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    private void Start()
    {
        playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    #endregion

    public void MoveForward(float fixedDeltaTime)
    {
        playerRigidbody.velocity += Vector3.forward * (playerStats.forwardSpeed * fixedDeltaTime);
    }

    public void MoveRight(float fixedDeltaTime)
    {
        playerRigidbody.velocity += Vector3.right * (playerStats.horizontalSpeed * fixedDeltaTime);
    }

    public void MoveLeft(float fixedDeltaTime)
    {
        playerRigidbody.velocity += Vector3.left * (playerStats.horizontalSpeed * fixedDeltaTime);
    }
}