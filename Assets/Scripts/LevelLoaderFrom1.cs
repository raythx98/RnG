﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaderFrom1 : MonoBehaviour
{
    public string scene;
    public Slider slider;

    public void LoadLevel(string scene)
    {
        this.scene = scene;
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously ()
    {
        yield return new WaitForSeconds(0.1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
