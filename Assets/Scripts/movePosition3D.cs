﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePosition3D : MonoBehaviour {

    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
	}
}
