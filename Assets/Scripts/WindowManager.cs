using UnityEngine;
using System.Collections.Generic;

public class WindowManager : Singleton<WindowManager> 
{
	private Dictionary<string, GameObject> windowDic = new Dictionary<string, GameObject>();

	public void OpenWindow(string key, params object[] args)
	{
		GameObject wind;
		if (windowDic.TryGetValue(key, out wind))
		{
			wind.SetActive(true);
			wind.BroadcastMessage("Call", args, SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			wind = GameObject.Instantiate<GameObject>(Resources.Load<GameObject> ("Prefabs/Windows/" + key));
			wind.transform.parent = transform;
			wind.transform.localPosition = new Vector3(0, 0, wind.transform.position.z);
			wind.transform.localScale = new Vector3(1, 1, 1);
			windowDic[key] = wind;
			wind.BroadcastMessage("Call", args, SendMessageOptions.DontRequireReceiver);
		}
	}

	public void CloseWindow(string key)
	{
		GameObject o;
		if (windowDic.TryGetValue(key, out o))
		{
			o.SetActive(false);
		}
	}

	public void CloseAllWindow()
	{
		foreach (GameObject o in windowDic.Values)
		{
			o.gameObject.SetActive(false);
		}
	}
}
