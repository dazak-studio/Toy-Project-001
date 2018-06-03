﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.XR.WSA;

public class PlayerShooting : MonoBehaviour
{
	public GameObject Bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			var angleDeg = transform.rotation.eulerAngles.y;
			var angle = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
			var bulletLength = 1.35f;
			Vector3 bulletInit = new Vector3( (float)Math.Sin(angle)* bulletLength, 0.5f, (float)Math.Cos(angle) * bulletLength);

			Debug.Log(transform.rotation);
			Instantiate(Bullet, transform.position+bulletInit, new Quaternion(0f,angleDeg,0f,0));
		}	
	}
}
