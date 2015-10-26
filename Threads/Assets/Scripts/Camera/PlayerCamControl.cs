using UnityEngine;
using System.Collections;

public class PlayerCamControl : MonoBehaviour
{

    public Camera MainCamera;
    public Transform Player;
    public float speed;
    public BoxCollider2D InitialBackgroundBounds;

    public BoxCollider2D BackgroundBounds
    {
        set
        {
            hiddenBounds = value;
            min = value.bounds.min;
            max = value.bounds.max;
        }

        get { return hiddenBounds; }
    }

    private BoxCollider2D hiddenBounds;
    private Vector3 min;
    private Vector3 max;


    public void Start()
    {
        BackgroundBounds = InitialBackgroundBounds;
    }


    public void FixedUpdate()
    {
        float x = transform.position.x;
        float y = transform.position.y;

            Vector2 vec = Vector2.Lerp(new Vector2(x, y), new Vector2(Player.position.x, Player.position.y), speed);
            x = vec.x;
            y = vec.y;

        float cameraHalfWidth = MainCamera.orthographicSize * ((float)Screen.width / Screen.height);

        // lock the camera to the right or left bound if we are touching it
        x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);

        // lock the camera to the top or bottom bound if we are touching it
        y = Mathf.Clamp(y, min.y + MainCamera.orthographicSize, max.y - MainCamera.orthographicSize);

        transform.position = new Vector3(x, y, transform.position.z);

    }

    public void TeleportFollow()
    {
        float x = Player.position.x;
        float y = Player.position.y;

        float cameraHalfWidth = MainCamera.orthographicSize * ((float)Screen.width / Screen.height);

        // lock the camera to the right or left bound if we are touching it
        x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);

        // lock the camera to the top or bottom bound if we are touching it
        y = Mathf.Clamp(y, min.y + MainCamera.orthographicSize, max.y - MainCamera.orthographicSize);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
