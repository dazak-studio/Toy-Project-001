using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    private float speed = 20.0f;
    private Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        this.transform.position += direction * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Init(Vector3 direction)
    {
        this.direction = direction;
    }
}
