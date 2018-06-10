using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{


	public float Speed = 6f;
	private float max_health = 100;
	public float health;

	public Slider healthBar;
	
	

	private Vector3 _movement;
	private Rigidbody _playerRigidbody;
	private int _floorMask;
	private readonly float camRayLength = 1000f;

	void Awake()
	{
		health = max_health;
		_floorMask = LayerMask.GetMask("Floor");
		_playerRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		var h = Input.GetAxisRaw("Horizontal");
		var v = Input.GetAxisRaw("Vertical");
		Move(h,v);
		Turning();
		healthBar.value = health / max_health;
	}

	void Move(float h, float v)
	{
		_movement.Set(h, 0f, v);
		_movement = _movement.normalized * Speed * Time.deltaTime;
		_playerRigidbody.MovePosition(transform.position+_movement);
	}

	void Turning()
	{
		var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, _floorMask))
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			_playerRigidbody.MoveRotation(newRotation);
		}
	}
}
