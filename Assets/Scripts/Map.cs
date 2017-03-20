using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject backBtn;
	public List<GameObject> mapList = new List<GameObject> ();

    void Start()
    {
        UIEventListener.Get(backBtn).onClick = OnBtnClick;
    }

    void OnBtnClick(GameObject o)
    {
        if (o == backBtn)
        {
            Singleton<Loading>.Instance.LoadScene("MainMenu");
        }
    }
}
