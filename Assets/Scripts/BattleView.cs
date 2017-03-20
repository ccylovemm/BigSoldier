using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleView : MonoBehaviour
{
    public GameObject backBtn;
    public GameObject forwardBtn;
    public UITexture headIcon;
    public UISlider hp;

    void Start()
    {
        UIEventListener.Get(backBtn).onPress = OnBtnPress;
        UIEventListener.Get(forwardBtn).onPress = OnBtnPress;
    }

    void OnBtnPress(GameObject o , bool state)
    {
        if (o == backBtn)
        {
            EventSystem.DispatchEvent(EType.MoveBack , state);
        }
        else if (o == forwardBtn)
        {
            EventSystem.DispatchEvent(EType.MoveForward, state);
        }
    }
}
