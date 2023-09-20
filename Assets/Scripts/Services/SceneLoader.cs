using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private readonly ICoroutineRunner _coroutineRunner;

    private readonly List<string> _buildIndexScenesNames = new();

    public SceneLoader(ICoroutineRunner coroutineRunner) =>
        _coroutineRunner = coroutineRunner;

    public void Load(string name, Action onLoaded = null) => 
        _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

    private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
    {
        int firstlevelIndex = 2;

        if (SceneManager.GetActiveScene().name == nextScene &&
            SceneManager.GetActiveScene().buildIndex < firstlevelIndex)
        {
            onLoaded?.Invoke();
            Debug.Log("Same scene. Do nothing");
            yield break;
        }

        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

        while (!waitNextScene.isDone)
        {
            yield return null;
        }

        onLoaded?.Invoke();
    }

    public string GetCurrentLevelName() =>
        SceneManager.GetActiveScene().name;

    public void GetBuildNamesFromBuildSettings()
    {
        int scenesCount = SceneManager.sceneCountInBuildSettings;
        string pathToScene;
        string sceneName;

        for (int i = 0; i < scenesCount; i++)
        {
            pathToScene = SceneUtility.GetScenePathByBuildIndex(i);
            sceneName = System.IO.Path.GetFileNameWithoutExtension(pathToScene);
            _buildIndexScenesNames.Add(sceneName);
        }
    }
}
