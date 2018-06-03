using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public GameObject enemy;
	
	// Use this for initialization
	void Start ()
	{
		Instantiate(enemy, new Vector3(2, 0, 2), new Quaternion(0,10,0,0));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
