﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    private Rigidbody rb;
	private bool NotGrounded,rope;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
		NotGrounded = false;
    }
	

    private void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Rope"))
        {
             NotGrounded = true;
			rb.useGravity = false;
        }
    }

	private void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.CompareTag("Rope"))
		{
			Vector3 distance = new Vector3((collision.rigidbody.transform.position.x - transform.position.x), (collision.rigidbody.transform.position.y - transform.position.y), (collision.rigidbody.transform.position.z - transform.position.z));
			Vector3 newPos = new Vector3(distance.x- transform.localScale.x / 2, 0, distance.z - transform.localScale.z/2);
			transform.position += newPos;
			rope = true;
            NotGrounded = true;

        }
	}

    private void OnCollisionExit(Collision collision)
    {
		NotGrounded = false;
		rb.useGravity = true;
		rope = false;
    }

	public bool notGrounded ()
	{
		return NotGrounded;
	}
}