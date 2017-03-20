using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCenter
{
    static public int currMapId = 0;
    static public int currStar = 0;
    static public bool isBattleOver = false;
    static public int currSelectBomb = 0;

    static public float fireTime;
    static public float fireCdTime;

    static public void SetFireCdTime()
    {
        fireTime = Time.time;
        fireCdTime = Time.time + (currSelectBomb == 0 ? 2.0f :(currSelectBomb == 1 ? 1.0f : 0.0f));
    }

    static public bool CanFire
    {
        get
        {
            return !isBattleOver && (Time.time > fireCdTime);
        }
    }

	static public bool IsPass(int mapId)
	{
		return PlayerPrefs.HasKey ("MapId" + mapId);
	}

	static public int GetStar(int mapId)
	{
		if (!IsPass (mapId)) return 0;
		return PlayerPrefs.GetInt ("MapId" + mapId);
	}

	static public void Save(int mapId , int star)
	{
		PlayerPrefs.SetInt ("MapId" + mapId , star);
	}
}
