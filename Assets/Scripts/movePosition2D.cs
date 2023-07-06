using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePosition2D : MonoBehaviour {

    public Rigidbody2D rb2D;

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb2D.MovePosition(rb2D.position + new Vector2(1,1) * Time.fixedDeltaTime);
	}
}
