using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
	public float startHealth = 100;
	public float currentHealth;
	public float sinkSpeed = 2.5f;
	public Image healthBar;

	BoxCollider boxCollider;
	GameObject playerObject;
	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;
	bool playerInRange;
	float timer;
	Player player;
	bool isDead;
	bool isSinking;

	void Awake ()
	{
		playerObject = GameObject.FindGameObjectWithTag("Player");
		player = playerObject.GetComponent<Player>();
		boxCollider = GetComponent <BoxCollider> ();
		currentHealth = startHealth;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == playerObject)
		{
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if(other.gameObject == playerObject)
		{
			playerInRange = false;
		}
	}
	// Use this for initialization
	void Start ()
	{
		currentHealth = startHealth;
	}


	void Update ()
	{
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && playerInRange && currentHealth > 0)
		{
			Attack ();
		}
		if(player.currentHealth <= 0)
		{
			// dead animation
		}
		if(isSinking)
		{
			transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	void Attack ()
	{
		timer = 0f;

		if(player.currentHealth > 0)
		{
			player.TakeDamage (attackDamage);
		}
	}

	public void TakeDamage (float amount)
	{
		currentHealth -= amount;

		healthBar.fillAmount = currentHealth / startHealth;

		if (currentHealth <= 0 && !isDead) {
			Death();
		}
	}

	public void StartSinking ()
	{
		GetComponent <NavMeshAgent> ().enabled = false;
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		Destroy (gameObject, 2f);
	}

	void Death()
	{
		isDead = true;
		boxCollider.isTrigger = true;
	}
}
