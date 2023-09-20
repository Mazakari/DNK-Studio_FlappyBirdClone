using System;

[Serializable]
public struct LevelSettings
{
    public LevelDifficulty difficulty;
    public float playerSpeed;
    public string levelSceneName;
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

        musicVolume = 0.5f;
        musicToggle = true;

        soundVolume = 0.5f;
        soundToggle = true;
    }
}
