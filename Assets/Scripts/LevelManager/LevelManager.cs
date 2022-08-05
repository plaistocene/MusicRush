using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables

    public float playerScale;
    public float groundScale;

    public float roadSpeed;
    public bool right;
    public bool left;

    public float groundLimitLeft;
    public float groundLimitRight;

    #endregion

    #region Unity Methods

    private void Start()
    {
        playerScale = GameObject.Find("Player").GetComponent<Transform>().localScale.x;
        groundScale = GameObject.Find("Ground").GetComponent<Transform>().localScale.x;

        groundLimitLeft = (groundScale * .5f) - (playerScale * .5f);
        groundLimitRight = -groundLimitLeft;
    }

    private void Update()
    {
        transform.Translate(Vector3.back * (roadSpeed * Time.deltaTime));

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
            if (transform.position.x > groundLimitRight)
            {
                // var calcPosition = transform.position;
                // transform.position = calcPosition;
                // Player moves right so ground moves left
                transform.Translate(Vector3.left * (roadSpeed * Time.fixedDeltaTime));
            }

            if (transform.position.x < groundLimitRight)
            {
                var position = transform.position;
                transform.Translate(groundLimitRight, position.y, position.z);
            }
        }

        if (left)
        {
            left = false;
            if (transform.position.x < groundLimitLeft)
            {
                // Player moves left so ground moves right
                transform.Translate(Vector3.right * (roadSpeed * Time.fixedDeltaTime));
            }

            if (transform.position.x > groundLimitLeft)
            {
                var position = transform.position;
                transform.Translate(groundLimitLeft, position.y, position.z);
            }
        }
    }

    #endregion
}