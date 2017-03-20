using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : MonoBehaviour 
{
	public int preId;
	public int currId;
	public GameObject state_pass;
	public GameObject state_curr;
	public GameObject state_none;

	void OnEnable()
	{
		if (DataCenter.IsPass (currId)) 
		{
			state_pass.SetActive (true);
			state_curr.SetActive (false);
			state_none.SetActive (false);
		} 
		else if (preId == 0 || DataCenter.IsPass (preId)) 
		{
			state_pass.SetActive (false);
			state_curr.SetActive (true);
			state_none.SetActive (false);
		} 
		else 
		{
			state_pass.SetActive (false);
			state_curr.SetActive (false);
			state_none.SetActive (true);
		}
	}

	void OnClick()
	{
		if (preId == 0 || DataCenter.IsPass (preId) || DataCenter.IsPass (currId)) 
		{
			DataCenter.currMapId = currId;
			DataCenter.isBattleOver = false;
			Singleton<Loading>.Instance.LoadScene ("Level" + currId);
		} 
	}
}
