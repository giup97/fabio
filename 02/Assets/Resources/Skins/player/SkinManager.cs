using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public List<Skin> Skins;
    [SerializeField] GameObject skinHolder;
    [SerializeField]GameObject Player;
    money GM;

    private void Start()
    {
        Skins = new List<Skin>(skinHolder.GetComponents<Skin>());
        GM = GameObject.Find("GameManager").GetComponent<money>();
        for(int i = 0; i < Skins.Count; i++)
        {
            Skins[i].setStatus(LoadSkinStatus(i));
        }

    }

    public void SaveSkinStatus(int id, bool unlock)
    {
        int temp;
        if (unlock)
        {
            temp = 1;
        }
        else
        {
            temp = 0;
        }
        PlayerPrefs.SetInt("Skin" + id.ToString(), temp); ;
    }

    public void ResetSkinStatus()
    {
        for (int i = 0; i < Skins.Count; i++)
        {

            PlayerPrefs.SetInt("Skin" + i.ToString(), 0);
        }
    }

    public bool LoadSkinStatus(int id)
    {
        int temp = PlayerPrefs.GetInt("Skin" + id.ToString()); 
        if(temp == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Changeskin()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        string nomeSkin = clickedButton.GetComponentInChildren<Text>().text;
        bool flag= false;
        int temp_id = 0;
        for(int i=0;i < Skins.Count; i++)
        {
            if(nomeSkin == Skins[i].nome)
            {
                
                if (LoadSkinStatus(Skins[i].id) == false)
                {
                    if (money.Amount - Skins[i].getprice() >= 0)
                    {
                        money.Amount = money.Amount - Skins[i].getprice();
                        SaveSkinStatus(Skins[i].id, true);
                        GM.SaveStatus();
                        flag = true;
                        temp_id = i;
                    }
                }
                else
                {
                    flag = true;
                    temp_id = i;
                }
            }
        }
        if (flag) {
            AnimatorOverrideController temp = Resources.Load("Skins/player/" + nomeSkin + "Controller") as AnimatorOverrideController;
            Player.GetComponent<Animator>().runtimeAnimatorController = temp as RuntimeAnimatorController;
            PlayerPrefs.SetInt("Current", temp_id);
            }
        else
        {
            Debug.Log("ERRORE");
        }
    }
}
