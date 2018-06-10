using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour {

    private float speed = 5.0f;
    private int hp = 100;
    private bool isEnemyHovered = false;
    public Text myHPText;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public GameObject bullet;

    private Transform hoveredEnemyTransform;

    // Use this for initialization
    private void Awake()
    {
        
    }

    void Start () {
		
	}

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(
            Input.GetAxis("Horizontal") * Time.deltaTime * speed,
            0.0f,
            Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update () {

        // change mouse pointer texture and a flag when hovered on enemy
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.name == "EnemyCube")
        {
            isEnemyHovered = true;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            hoveredEnemyTransform = hit.transform;
        }
        else
        {
            isEnemyHovered = false;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }

        if(Input.GetMouseButtonDown(0) && isEnemyHovered)
        {
            Shoot();
        }
    }

    public void DecreaseHP()
    {
        hp -= 50;
        myHPText.text = "My HP : " + hp;
        if(hp <= 0)
        {
            // die
        }
    }

    private void Shoot()
    {
        Vector3 direction = (hoveredEnemyTransform.position - this.transform.position).normalized;
        GameObject newBullet = Instantiate(bullet, 
            this.transform.position + direction * 1.5f, 
            Quaternion.identity);
        newBullet.GetComponent<BulletScript>().Init(direction);
    }
}
