using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    private int hp;
    private Transform hpBarTransform;
    private Vector3 velocity;

    private void Awake()
    {
        hp = 100;
        hpBarTransform = transform.GetChild(1).transform;
        velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Use this for initialization
    void Start () {
		
	}

    private void FixedUpdate()
    {
        if (velocity.magnitude <= 0.1f)
        {
            velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else
        {
            velocity -= velocity.normalized * 3.0f * Time.deltaTime;
        }
        this.transform.position += velocity * Time.deltaTime;
    }

    // Update is called once per frame
    void Update () {
	}

    public void HitByBullet(Vector3 direction)
    {
        DecreaseHP();
        Slide(direction);
        DieIfHPZero();
    }

    private void DecreaseHP()
    {
        hp -= 50;
        hpBarTransform.localScale = new Vector3( (float)hp / 100, 0.1f, 0.1f);
    }

    private void Slide(Vector3 direction)
    {
        velocity = direction * 3.0f;
    }

    private void DieIfHPZero()
    {
        if (hp <= 0)
        {
            // die
            Destroy(this.gameObject);
        }
    }
}
