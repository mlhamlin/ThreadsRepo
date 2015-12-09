using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1.0f;
    public Sprite FacingLeft;
    public Sprite FacingRight;
    public SpriteRenderer Renderer;

    // Use this for initialization
    void Start () {
	
	}


    void Update()
    {
        if(!DialogController.Instance.Active)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

            if (move.x >= 0f)
            {
                Renderer.sprite = FacingRight;
            } else
            {
                Renderer.sprite = FacingLeft;
            }

            transform.position += move * speed * Time.deltaTime;
        }
    }
}
