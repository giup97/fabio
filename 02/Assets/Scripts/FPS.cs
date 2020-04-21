using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPS : MonoBehaviour
{
    public Text tx;
    float var = 0.0f;

    // Update is called once per frame
    void Update()
    {
        var = (1.0f / Time.deltaTime);
        tx.text = var.ToString();
    }
}
