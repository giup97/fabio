using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject losingscreen;
    [SerializeField] GameObject pausescreen ;
    private bool pause = false;
    money moneysystem;


    public void Start()
    {
        Time.timeScale = 1f;
        moneysystem = this.gameObject.GetComponent<money>();
    }
    void Update()
    {
        if (Player.death)
        {
            losingscreen.SetActive(true);
            Time.timeScale = 0;
            moneysystem.SaveStatus();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            pause = !pause;
            Pause(pause);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }

    }

    public void reload()
    {
        SceneManager.LoadScene(0);  
    }

    public void Pause(bool ispaused)
    {
        if (pause == true) 
        {
            Time.timeScale = 0f;
            pausescreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausescreen.SetActive(false);
        }
    }
    public void resume()
    {
        Time.timeScale = 1f;
        pausescreen.SetActive(false);
    }

}
