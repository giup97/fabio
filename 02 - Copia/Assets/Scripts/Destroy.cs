using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    
    [SerializeField] private GameObject Destruction_point;
    public int difficoulty;
    void Start()
    {
        Destruction_point = GameObject.Find("destruction point");
    }
    void Update()
    {
        if ( this.transform.position.x < Destruction_point.transform.position.x )
        {
            if (difficoulty == difficultyManager.difficulty)
            {
                this.gameObject.SetActive(false);
                Debug.Log("Sono stato disattivato");
            }
            else
            {

                Destroy(this.gameObject);
                Debug.Log("Sono stato distrutto");
            }
        }
        
    }
}
