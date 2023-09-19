using System;
using UnityEngine;

[Serializable]
public struct LevelSettings
{
    public LevelDifficulty difficulty;
    public float playerSpeed;
    public GameObject wallsPrefab;
}

[Serializable]
public class GameSettingsData
{
    public LevelSettings levelSettings;

    public float musicVolume;
    public bool musicToggle;

    public float soundVolume;
    public bool soundToggle;

    public GameSettingsData(LevelSettings defaultLevelSettings)
	{
        levelSettings = defaultLevelSettings;

        Debug.Log(levelSettings.difficulty);
        Debug.Log(levelSettings.playerSpeed);
        Debug.Log(levelSettings.wallsPrefab.name);

        musicVolume = 0.5f;
        musicToggle = true;

        soundVolume = 0.5f;
        soundToggle = true;
    }
}
