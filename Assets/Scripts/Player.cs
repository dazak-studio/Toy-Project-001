using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public float startHealth = 100;
	public float currentHealth;
	public Slider healthSlider;
	public Image healthBar;

	public float moveSpeed = 6f;

	Vector3 movement;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100f;

	bool isDead;

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		playerRigidbody = GetComponent<Rigidbody>();
		currentHealth = startHealth;
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Move(h, v);
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);

		movement = movement.normalized * moveSpeed * Time.deltaTime;

		playerRigidbody.MovePosition(transform.position + movement);
	}


	void Start() {
		currentHealth = startHealth;
		moveSpeed = 7f;
	}

	public void TakeDamage(float amount)
	{
		currentHealth -= amount;

		healthBar.fillAmount = currentHealth / startHealth;

		if (currentHealth <= 0 && !isDead) {
			Death();
		}
	}

	void Death()
	{
		isDead = true;
	}
}
