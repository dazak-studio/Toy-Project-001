using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[SerializeField] private float _forwardSpeed;
	[SerializeField] private float _backwardSpeed;
	[SerializeField] private float _rotateSpeed;
	
	private Transform _transform;
	
	private void Start ()
	{
		_transform = GetComponent<Transform>();
	}
	
	private void FixedUpdate()
	{
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");

		/* forward and backward move */		
		var velocity = Vector3.forward * vertical;
		velocity = _transform.TransformDirection(velocity);

		if (vertical > 0.1f)
		{
			velocity *= _forwardSpeed;
		} else if (vertical < 0.1f)
		{
			velocity *= _backwardSpeed;
		}

		_transform.localPosition += velocity * Time.fixedDeltaTime;
		
		/* rotate */
		_transform.Rotate(0, horizontal * _rotateSpeed, 0);
	}
}
