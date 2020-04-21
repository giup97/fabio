using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficultyManager : MonoBehaviour
{
    public static int difficulty=1;
    [SerializeField] private GameObject Player;
    public Text tx;
    int temp;
    private void Awake()
    {
        difficulty = 1;
    }


    private void Update()
    {
        temp = (int)Player.transform.position.x;
        tx.text = temp.ToString();
        if (Player.transform.position.x > 100)
        {
            difficulty = 2;
        }
    }
}
