using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript3D : MonoBehaviour {

    public GameObject holder;
    private Rigidbody body;

    float moveCoef = 100;
    float rotateCoef = 100;

	// Use this for initialization
	void Start () {
        body = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
        this.body.AddForce(moveCoef*(holder.transform.position - this.transform.position));
        this.body.AddTorque(-rotateCoef * this.transform.rotation.x, -rotateCoef * this.transform.rotation.y, -rotateCoef * this.transform.rotation.z);
	}
}
