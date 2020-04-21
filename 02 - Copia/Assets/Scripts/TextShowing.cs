using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShowing: MonoBehaviour 
{
    public Text tx;
    

    void Update()
    {
        tx.text = money.Amount.ToString();
    }
}
