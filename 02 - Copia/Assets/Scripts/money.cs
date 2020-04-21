using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    public static int Amount = 0;


    public void Awake()
    {
        Amount = LoadStatus();
    }
    public void SaveStatus()
    {
        PlayerPrefs.SetInt("Money", Amount);
    }

    public int LoadStatus()
    {
        return PlayerPrefs.GetInt("Money");
    }

    public void AddMoney()
    {
        Amount = Amount + 100;
    }
}
