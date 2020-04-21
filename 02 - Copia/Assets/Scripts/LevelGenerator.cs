using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
 
    
    [SerializeField] private Transform Start_part;
    [SerializeField] private GameObject player;
    
    private Vector3 last ;
    private float x;
    [SerializeField] float distance_between = 4f;
    private const float SPAWN_DISTANCE = 100f;


    void Awake()
    {
        last = Start_part.transform.Find("end").position;
    }

    void Update()
    {
        if(Vector3.Distance(player.transform.position, last) < SPAWN_DISTANCE)
        {
            Spawn_Part(last);
        }
    }

    void Spawn_Part(Vector3 spawnposition)
    {
        
        GameObject newplatform = Pooling.Instance.GetPlatform();
        float x = Vector3.Distance(newplatform.transform.Find("start").position, newplatform.transform.Find("end").position);
        newplatform.transform.position = spawnposition + new Vector3(distance_between + x/2 , 0 , 0) ;
        Debug.Log(x.ToString());
        newplatform.SetActive(true);
        SetActiveAllChildren(newplatform.transform, true);
        last = newplatform.transform.Find("end").position;
    }

    private void SetActiveAllChildren(Transform transform, bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);

            SetActiveAllChildren(child, value);
        }
    }
}
