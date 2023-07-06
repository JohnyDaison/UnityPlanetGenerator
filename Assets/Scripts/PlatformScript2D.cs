using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript2D : MonoBehaviour {

    public GameObject holder;
    private Rigidbody2D body;

    float moveCoef = 200;
    float rotateCoef = 1000;

	void Start () {
        body = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		
        this.body.AddForce(moveCoef*(holder.transform.position - this.transform.position));
        this.body.AddTorque(-rotateCoef * transform.rotation.z);
	}
}
