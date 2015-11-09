using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1.0f;

    // Use this for initialization
    void Start () {
	
	}


    void Update()
    {
        if(!DialogController.Instance.Active)
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }
    }
}
