using UnityEngine;

public class PlayerHorizontalMovement : MonoBehaviour
{
    #region Variables

    public PlayerStats playerStats;
    public bool moveByTouch;


    private Vector3 _mouseStartPos, _playerStartPos;
    private Camera _camera;

    #endregion

    #region Unity Methods

    private void Start()
    {
        playerStats = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
        playerStats.CalculateMovementLimitX();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveByTouch = true;
            PlayerStats.StartGame();

            var newPlane = new Plane(Vector3.up, 0f);
            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (newPlane.Raycast(ray, out var distance))
            {
                _mouseStartPos = ray.GetPoint(distance);
                _playerStartPos = new Vector3(0, 5, 31);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            moveByTouch = false;
        }

        if (moveByTouch)
        {
            var plane = new Plane(Vector3.up, 0f);

            var ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out var distance))
            {
                Vector3 mousePos = ray.GetPoint(distance);
                Vector3 desirePos = mousePos - _mouseStartPos;
                Vector3 move = _playerStartPos + desirePos;

                move.x = Mathf.Clamp(move.x, -playerStats.GetMovementLimitX(), playerStats.GetMovementLimitX());
                move.z = 0f;

                var player = transform.position;

                var xPos = Mathf.Lerp(player.x, move.x, Time.deltaTime * playerStats.GetHorizontalSpeed());

                player = new Vector3(xPos, player.y, player.z);

                transform.position = player;
            }
        }
    }

    #endregion
}