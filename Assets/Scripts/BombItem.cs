using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : MonoBehaviour
{
    public GameObject select;
    public GameObject bombBtn;
    public UISprite cdMask;
    public int bombIndex = 0;

    void Start()
    {
        UIEventListener.Get(bombBtn).onClick = OnBtnClick;
    }

    void Update()
    {
        if (Time.time > DataCenter.fireCdTime)
        {
            cdMask.fillAmount = 0.0f;
        }
        else
        {
            cdMask.fillAmount = (DataCenter.fireCdTime - Time.time) / (DataCenter.fireCdTime - DataCenter.fireTime);
        }
    }

    void OnBtnClick(GameObject o)
    {
        if(o == bombBtn)
        {
            DataCenter.currSelectBomb = bombIndex;
            select.transform.parent = transform;
            select.transform.localPosition = new Vector3(0 , 0 , 0);
        }
    }
}
