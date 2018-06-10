using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework.Constraints;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public GameObject enemy;
	public GameObject player;
	private List<GameObject> enemyList = new List<GameObject>();
	private int level = 1;

	
	// Use this for initialization
	void Start ()
	{
		
		enemyList.Add(Instantiate(enemy, new Vector3(4f, 0, 4f), new Quaternion(0,10,0,0)));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isFinished())
		{
			enemyList.Clear();
			level++;
			enemeySpawn(level);
			player.transform.position = new Vector3(0,0,-8);
		}
	}

	private void enemeySpawn(int level)
	{
		for(int i =0; i < level; i++)
			enemyList.Add(Instantiate(enemy, new Vector3(-4f+2*i, 0, 4), new Quaternion(0,10,0,0)));
	}

	bool isFinished()
	{
		bool finish = true;
		for (int i = 0; i < enemyList.Count; i++)
		{
			if (enemyList[i] != null)
			{
				finish = false;
			}
		}

		return finish;
	}
}
