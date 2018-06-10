using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyManager : MonoBehaviour {

	public Slider healthBar;
	private float max_health = 100;
	public float health;
	
	// Use this for initialization
	void Start ()
	{
		health = max_health;
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.value = health / max_health;
		if (health < 0)
		{
			Destroy(this.gameObject);
		}
	}
}
