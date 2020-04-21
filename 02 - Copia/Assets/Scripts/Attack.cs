using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    float attackdelay = 0.3f;
    float startattack;

    public float attackrangX;
    public float attackrangeY;
    public Transform attack_pos;
    public LayerMask whatisenemy;
    int damage = 1;

    void Update()
    {
       // if startattack <= 0)
        //{

            if (Input.GetButtonDown("Fire1"))
            {
                Collider2D[] Hit_enemis = Physics2D.OverlapBoxAll(attack_pos.position, new Vector2(attackrangX, attackrangeY), 0, whatisenemy);
                for (int i = 0; i < Hit_enemis.Length; i++)
                {
                    Hit_enemis[i].GetComponent<Enemy>().Takedamage(damage);
                }
            }
            startattack = attackdelay;
       // }
       // else
       // {
            //startattack -= Time.deltaTime;
        //}
    }
    
    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attack_pos.position, new Vector3(attackrangX, attackrangeY, 0));
    }
}
