using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour {

    private float speed = 5.0f;
    private int hp = 100;
    public Text myHPText;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;


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
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if(hit.transform.name == "EnemyCube")
            {
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, cursorMode);
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
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
}
