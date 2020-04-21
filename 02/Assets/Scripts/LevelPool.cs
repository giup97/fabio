using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPool : MonoBehaviour
{
    public  List<GameObject> Easy = new List<GameObject>();
    public List<GameObject> Medium = new List<GameObject>();

    public List<GameObject> getList(int difficutly)
    {
        if(difficutly == 1)
        {
            return Easy;
        }
        if (difficutly == 2)
        {
            return Medium;
        }
        else return null;
    }
}