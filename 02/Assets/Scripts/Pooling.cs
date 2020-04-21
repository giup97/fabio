using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pooling : MonoBehaviour
{
    private static Pooling _instance;
    public static Pooling Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField] public List<GameObject>  PooledObject ;
    private int platAmount = 10;
    private int current_diff;
    void Awake()
    {
        

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        PooledObject = new List<GameObject>(platAmount);

        for (int i=0; i< platAmount; i++)
        {
            GameObject temp = Instantiate(Choose_piece());
            temp.SetActive(false);
            PooledObject.Add(temp);
        }
    }

    private void Start()
    {
        current_diff = difficultyManager.difficulty;
    }

    private void Update()
    {
        if(current_diff != difficultyManager.difficulty)
        {
            ChangeDiff();
            current_diff = difficultyManager.difficulty;
        }

    }
    public GameObject GetPlatform()
    {
        foreach(GameObject ob in PooledObject)
        {
            if (!ob.activeInHierarchy)
            {
                ob.SetActive(true);
                return ob;
            }
        }

        GameObject temp = Instantiate(Choose_piece());
        temp.transform.SetParent(transform);
        PooledObject.Add(temp);

        return temp;
    }

    public GameObject Choose_piece()
    {
        GameObject LevelManager = GameObject.Find("GameController");
        LevelPool platforms = LevelManager.GetComponent<LevelPool>();

        int temp = Random.Range(0, platforms.getList(difficultyManager.difficulty).Count);
        return platforms.getList(difficultyManager.difficulty)[temp];
    }

    public void ChangeDiff()
    {

        for (int j=0; j<PooledObject.Count; j++)
        {
            if (!PooledObject[j].activeInHierarchy)
            {
                PooledObject[j].SetActive(true);
            }
        }
        
        PooledObject.Clear();

        for (int i = 0; i < platAmount; i++)
        {
            GameObject temp = Instantiate(Choose_piece());
            temp.SetActive(false);
            PooledObject.Add(temp);
        }
    }
}
