using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyManager : MonoBehaviour
{
	private Transform player;
	public GameObject Bullet;
	public Slider healthBar;
	private float max_health = 100;
	public float health;
	private float shootTime;
	private NavMeshAgent nav;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("player").transform;
		nav = GetComponent<NavMeshAgent>();
		health = max_health;
		shootTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		nav.SetDestination(player.position);
		healthBar.value = health / max_health;
		
		if(Time.time>shootTime+1f)
			BulletShooting();
		if (health < 0)
		{
			Destroy(this.gameObject);
		}
	}

	
	void BulletShooting()
	{
		shootTime = Time.time;
		var angleDeg = transform.rotation.eulerAngles.y;
		var angle = transform.rotation.eulerAngles.y * Mathf.Deg2Rad;
		var bulletLength = 2f;
		Vector3 bulletInit = new Vector3( (float)Math.Sin(angle)* bulletLength, 0f,(float)Math.Cos(angle) * bulletLength);

		//Euler angle is the normal angle vectors which is used in UI
		Quaternion roation_bullet = Quaternion.Euler(90, angleDeg, 0);

		//Rotation Error
		Instantiate(Bullet, transform.position+bulletInit, roation_bullet);
		shootTime = Time.time;
	}
}
