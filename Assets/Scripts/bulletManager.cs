using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour {
	public Rigidbody _rb;
	public float BulletVelocity = 10;
	
	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody>();
		var angle = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
		_rb.velocity = new Vector3( (float)Math.Sin(angle)* BulletVelocity, 0f,(float)Math.Cos(angle) * BulletVelocity);
	}
	
	void Update () {
		//Bullet Removing 
		if (transform.position.magnitude > 50)
		{
			Destroy(this.gameObject);
		}
	}
	
	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.CompareTag("enemy"))
		{
			col.gameObject.GetComponent<enemyManager>().health -= 10;
		}
		if (col.gameObject.CompareTag("player"))
		{
			col.gameObject.GetComponent<PlayerManager>().health -= 10;
		}
		Destroy(this.gameObject);
	}
}
