using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CameraController : MonoBehaviour
{
	public Transform FocusObjectTransform;
	
	private Transform _transform;
	private Vector3 _originPoint;

	private void Awake()
	{
		_transform = GetComponent<Transform>();
		_originPoint = _transform.position;
	}

	private void LateUpdate()
	{
		if (FocusObjectTransform != null)
			_transform.position = FocusObjectTransform.position + _originPoint;
	}
}
