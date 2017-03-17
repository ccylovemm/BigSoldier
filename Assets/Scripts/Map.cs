using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject backBtn;
    public GameObject fightBtn;

    void Start()
    {
        UIEventListener.Get(backBtn).onClick = OnBtnClick;
        UIEventListener.Get(fightBtn).onClick = OnBtnClick;
    }

    void OnBtnClick(GameObject o)
    {
        if (o == backBtn)
        {
            Singleton<Loading>.Instance.LoadScene("MainMenu");
        }
        else if (o == fightBtn)
        {
            Singleton<Loading>.Instance.LoadScene("Level1");
        }
    }
}
