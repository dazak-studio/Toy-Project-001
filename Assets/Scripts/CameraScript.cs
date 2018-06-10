using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject player;
    public GameObject camera;

    private float currentShakeTime = 0.0f;
    private const float initialShakeTime = 0.5f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame

    private void FixedUpdate()
    {
        this.transform.position = player.transform.position;
        if (currentShakeTime > 0.0f)
        {
            camera.transform.localPosition = new Vector3(0.5f, 0.0f, 0.0f)
                * Mathf.Sin(currentShakeTime * 360.0f / initialShakeTime);
            currentShakeTime -= Time.deltaTime;
        }
    }

    void Update () {
        
    }
    
    public void Shake()
    {
        currentShakeTime = initialShakeTime;
    }
}
