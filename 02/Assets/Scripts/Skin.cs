using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public int id;
    [SerializeField]public string nome;
    [SerializeField] bool unlock;
    [SerializeField] int price;
    [SerializeField] Sprite icon;
    public int getprice()
    {
        return price;
    }
    public bool getStatus()
    {
        return unlock;
    }
    public void setStatus(bool status)
    {
        unlock = status;
    }
}
