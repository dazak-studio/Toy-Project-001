using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{


	public float speed = 6f;

	private Vector3 movement;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 1000f;

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");
		Move(h,v);
		Turning();
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position+movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}
}
