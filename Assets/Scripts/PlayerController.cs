using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : CubeController {

	private static bool IsLeftMouseClicked { get { return Input.GetMouseButtonDown(0); } }

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
		shootPoint.y = 0;		
		var shootPointNorm = shootPoint.normalized;
		var initialPointForBullet = _transform.position + shootPointNorm;
		initialPointForBullet.y = _transform.position.y;
		var dz = shootPointNorm.z;
		var dx = shootPointNorm.x;
		var rotateDegree = Mathf.Atan2(dz, dx) * Mathf.Rad2Deg;
		var bullet = Instantiate(BulletPrefab, initialPointForBullet, Quaternion.identity);	
		var bulletController = bullet.GetComponent<BulletController>();
			
		bulletController.SetTrigger(shootPointNorm, rotateDegree);
	}

	private void OnClicked()
 	{
		var mousePos = Input.mousePosition + Vector3.forward * 10;		
		var worldPointFromMousePosition = _mainCamera.ScreenToWorldPoint(mousePos);
		Shoot(worldPointFromMousePosition - _transform.position);
 	}
 }
