using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1.0f;
    public Sprite FacingLeft;
    public Sprite FacingRight;
    public SpriteRenderer Renderer;
    public Footsteps footsteps;

    // Use this for initialization
    void Start () {
	
	}


    void Update()
    {
        if(!DialogController.Instance.Active)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

            if (move.x > 0f)
            {
                Renderer.sprite = FacingRight;
            } else if (move.x < 0f)
            {
                Renderer.sprite = FacingLeft;
            }

            if (move != new Vector3(0f,0f,0f))
            {
                footsteps.Walking(Time.deltaTime);
            } else
            {
                footsteps.StopWalking();
            }

            transform.position += move * speed * Time.deltaTime;
        }
    }
}
