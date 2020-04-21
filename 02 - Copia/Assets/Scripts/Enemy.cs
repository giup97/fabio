using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health=1;
    public float speed_movement = 1.2f;
    public Transform Ground_detection;
    Vector2 direction = new Vector2(-1,0);
    private bool moveleft = true;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Checkhealth();
        movement();

        RaycastHit2D ground = Physics2D.Raycast(Ground_detection.position, Vector2.down, 2f);
        if(ground.collider == false)
        {
            if (moveleft)
            {
                transform.eulerAngles = new Vector3(0 ,180,0);
                moveleft = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveleft = true;

            }
        }
    }

    public void Takedamage(int damage)
    {
        health -= damage;
    }
    void Checkhealth()
    {
        if (health <= 0)
        {
            Debug.Log("SONO MORTO");
            Destroy(gameObject);
        }
    }
    void movement()
    {
        transform.Translate(direction * speed_movement * Time.deltaTime);
    }
}
