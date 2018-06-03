using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private int hp;
    private Transform hpBarTransform;

    private void Awake()
    {
        hp = 100;
        hpBarTransform = transform.GetChild(1).transform;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void DecreaseHP()
    {
        Debug.Log("Decrease HP");
        hp -= 50;
        hpBarTransform.localScale = new Vector3( (float)hp / 100, 0.1f, 0.1f);
        if(hp <= 0)
        {
            // die
        }
    }
}
