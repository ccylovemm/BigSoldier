using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject map;

    void Start()
    {
        UIEventListener.Get(startBtn).onClick = OnBtnClick;
    }

    void OnBtnClick(GameObject o)
    {
        if (o == startBtn)
        {
			Singleton<Loading>.Instance.LoadScene ("Map");
        }
    }
}
