using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private float speed = 5.0f;

    // Use this for initialization
    private void Awake()
    {
        
    }

    void Start () {
		
	}

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(
            Input.GetAxis("Horizontal") * Time.deltaTime * speed, 
            0.0f, 
            Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
