using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyscript : MonoBehaviour
{   
    void Update()
    {
        if (gameObject.transform.parent.gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
    }
}
