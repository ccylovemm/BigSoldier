using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultView : MonoBehaviour 
{
	public GameObject backBtn1;
	public GameObject restartBtn;
	public GameObject backBtn2;
	public GameObject nextBtn;

	public GameObject star1;
	public GameObject star2;
	public GameObject star3;

	public GameObject lose;
	public GameObject win;

	void Start()
	{
		UIEventListener.Get (backBtn1).onClick = OnBtnClick;
		UIEventListener.Get (restartBtn).onClick = OnBtnClick;
		UIEventListener.Get (backBtn2).onClick = OnBtnClick;
		UIEventListener.Get (nextBtn).onClick = OnBtnClick;
	}

	void OnEnable()
	{
		if (DataCenter.currStar == 1) 
		{
			lose.SetActive (true);
			win.SetActive (false);
		}
		else 
		{
			lose.SetActive (false);
			win.SetActive (true);
			star1.SetActive (false);
			star2.SetActive (false);
			star3.SetActive (false);
			StartCoroutine (ShowEffect());
		}
	}

	IEnumerator ShowEffect()
	{
		yield return new WaitForSeconds (0.2f);
		star1.SetActive (true);
		star1.transform.localScale = Vector3.one * 5;
		iTween.ScaleTo (star1 , iTween.Hash("scale" , Vector3.one , "time" , 0.1f , "easetype" , iTween.EaseType.easeInExpo));
		yield return new WaitForSeconds (0.2f);
		star2.SetActive (true);
		star2.transform.localScale = Vector3.one * 5;
		iTween.ScaleTo (star2 , iTween.Hash("scale" , Vector3.one , "time" , 0.1f , "easetype" , iTween.EaseType.easeInExpo));
		yield return new WaitForSeconds (0.2f);
		star3.SetActive (true);
		star3.transform.localScale = Vector3.one * 5;
		iTween.ScaleTo (star3 , iTween.Hash("scale" , Vector3.one , "time" , 0.1f , "easetype" , iTween.EaseType.easeInExpo));
	}

	void OnBtnClick(GameObject o)
	{
		if(o == backBtn1 || o == backBtn2)
		{
			Singleton<Loading>.Instance.LoadScene ("Map");
		}
		else if(o == restartBtn)
		{
			DataCenter.isBattleOver = false;
			Singleton<Loading>.Instance.LoadScene ("Level" + DataCenter.currMapId);
		}
		else if(o == nextBtn)
		{
			DataCenter.isBattleOver = false;
			Singleton<Loading>.Instance.LoadScene ("Level" + (DataCenter.currMapId + 1));
		}

		Singleton<WindowManager>.Instance.CloseWindow (WindowKey.ResultView);
	}
}
