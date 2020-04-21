using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField]private bool invincible = false;
    Animator anim;
    private bool isTriggered = false;
    public static bool death;
    Collider2D coll;
    void Start()
    {
        health = 2;
        anim = GetComponent<Animator>();
        death = false;
        coll = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invincible)
        {
            if (collision.collider.gameObject.CompareTag("enemy"))
            {
                Physics2D.IgnoreCollision(coll, collision.collider);
                health--;
                Debug.Log(health);
                invincible = true;
                StartCoroutine(blink());
                resetInv();
                isTriggered = true;
                if(health <= 0)
                {
                    death = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered)
        {
            if (collision.gameObject.CompareTag("death"))
            {
                death = true;
            }
            if (collision.gameObject.CompareTag("money"))
            {
                money.Amount += 1;
                collision.gameObject.SetActive(false);
                Debug.Log(money.Amount);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isTriggered = false;
    }

    void resetInv()
    {
        invincible = false;
    }

    IEnumerator blink()
    {
        anim.SetLayerWeight(1, 1);

        yield return new WaitForSeconds(1f);

        anim.SetLayerWeight(1, 0);
    }
}
