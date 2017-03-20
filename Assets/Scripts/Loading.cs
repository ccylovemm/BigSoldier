using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : Singleton<Loading>
{
    public GameObject loadingBg1;
    public GameObject loadingBg2;

	private bool isLoading = false;

    public void LoadScene(string sceneName)
    {
		if (isLoading)return;
		isLoading = true;
        StartCoroutine(LoadScene_(sceneName));
    }

    IEnumerator LoadScene_(string sceneName)
    {
        loadingBg1.transform.localPosition = new Vector3(-937, 0, 0);
        loadingBg2.transform.localPosition = new Vector3(937, 0, 0);
        iTween.MoveTo(loadingBg1, iTween.Hash("position", new Vector3(-283, 0, 0) , "islocal" , true , "easetype", iTween.EaseType.linear, "time" , 0.5f));
        iTween.MoveTo(loadingBg2, iTween.Hash("position", new Vector3(283, 0, 0), "islocal", true, "easetype", iTween.EaseType.linear, "time" , 0.5f));

        yield return new WaitForSeconds(1.0f);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        yield return asyncOperation;

        yield return new WaitForSeconds(0.2f);

        loadingBg1.transform.localPosition = new Vector3(-283, 0, 0);
        loadingBg2.transform.localPosition = new Vector3(283, 0, 0);
        iTween.MoveTo(loadingBg1, iTween.Hash("position", new Vector3(-937, 0, 0), "islocal", true, "easetype", iTween.EaseType.easeInQuad, "time", 0.6f));
        iTween.MoveTo(loadingBg2, iTween.Hash("position", new Vector3(937, 0, 0), "islocal", true, "easetype", iTween.EaseType.easeInQuad, "time", 0.6f));
		isLoading = false;
	}
}
