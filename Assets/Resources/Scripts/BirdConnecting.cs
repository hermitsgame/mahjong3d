﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BirdConnecting : MonoBehaviour {
    public static BirdConnecting instance;

    void Start()
    {
        instance = this;
        StartConnecting();
    }

    public void StartConnecting()
    {
        // 準備進入遊戲場景
        //StartCoroutine(DisplayLoadingScreen("main"));
    }

    IEnumerator DisplayLoadingScreen(string sceneName)
    {

        int displayProgress = 0;
        int toProgress = 0;

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        async.allowSceneActivation = false;

        while (async.progress < 0.9f)
        {
            toProgress = (int)async.progress * 100;

            while (displayProgress < toProgress)
            {
                ++displayProgress;
                //SetLoadingPercentage(displayProgress);
                yield return null;
            }
        }

        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            //SetLoadingPercentage(displayProgress);
            yield return null;
        }

        GetComponent<SoundEffect>().FadeOut();     //背景音樂淡出
        yield return new WaitForSeconds(3.0f);
        Lobby_UIManager.instance.SetConnectingDone();  //讀取畫面淡出
        yield return new WaitForSeconds(1.5f);

        async.allowSceneActivation = true;  //進入下一場景
    }

    private void SetLoadingPercentage(int progress)
    {
        //loadText.text = progress.ToString() + " %";
        //loadImage.fillAmount = (float)progress / 100;
        //Debug.Log("async.progress = " + progress);
    }
}
