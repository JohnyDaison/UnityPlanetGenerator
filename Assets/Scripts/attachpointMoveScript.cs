using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachpointMoveScript : MonoBehaviour {

    private Rigidbody2D body;
    private float speed = 40f;

	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
        body.AddForce(new Vector2(0f, speed));
	}
	
	// Update is called once per frame
	void Update () {
        if(body.position.y > 5)
        {
            body.AddForce(new Vector2(0f, -speed));
        }

        if(body.position.y < -5)
        {
            body.AddForce(new Vector2(0f, speed));
        }
	}
}
