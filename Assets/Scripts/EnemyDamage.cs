using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using MadLevelManager;

public class EnemyDamage : MonoBehaviour
{
    public float hp = 100.0f;
    public SkeletonAnimation spineboy;

    void OnDamage(float damage)
    {
        hp -= 100;

        if (hp > 0)
        {
            spineboy.state.SetAnimation(0, "hit", false);
            spineboy.state.AddAnimation(0, "idle", true, 0);
        }
        else
        {
            if (hp >= 0)
            {
                spineboy.state.SetAnimation(0, "death", false).TrackEnd = float.PositiveInfinity;
                StartCoroutine(Kill());
            }
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(2.0f);
        MadLevelProfile.SetLevelBoolean(MadLevel.currentLevelName, "star_3", true);
        MadLevelProfile.SetCompleted(MadLevel.currentLevelName, true);
        MadLevel.LoadLevelByName("Main");
    }
}
