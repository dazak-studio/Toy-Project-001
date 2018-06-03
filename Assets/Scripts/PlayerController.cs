using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : CubeController {

	private bool IsLeftMouseClicked { get { return Input.GetMouseButtonDown(0); } }

	[SerializeField] private Camera _mainCamera;
	[SerializeField] private float _forwardSpeed;
	[SerializeField] private float _backwardSpeed;
	[SerializeField] private float _rotateSpeed;
	
	private Transform _transform;

	#region Unity-Callbacks
	private void Start ()
	{
		_transform = GetComponent<Transform>();
	}
	
	protected new void FixedUpdate()
	{
		base.FixedUpdate();
		
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

	private void Update()
	{
		if (IsLeftMouseClicked)
			OnClicked();
	}

	#endregion
	
	public override void Shoot(Vector3 shootPoint)
	{
		if (!IsShootable) return;
		
		ShootCooldownLeft = ShootCooldown;

		shootPoint.y = _transform.position.y;
		var shootPointNorm = shootPoint.normalized;
		var initialPointForBullet = _transform.TransformDirection(shootPointNorm);				
		var dy = initialPointForBullet.y - _transform.position.y;
		var dx = initialPointForBullet.x - _transform.position.x;
		var rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
		var bullet = Instantiate(BulletPrefab, initialPointForBullet, Quaternion.identity);
		var bulletController = bullet.GetComponent<BulletController>();
			
		bulletController.SetTrigger(shootPointNorm, rotateDegree);
	}

	private void OnClicked()
	{
		var worldPointFromMousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
		print(worldPointFromMousePosition);
		
		Shoot(worldPointFromMousePosition);
	}
}
