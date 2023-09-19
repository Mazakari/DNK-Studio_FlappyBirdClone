using System;

[Serializable]
public class PlayerProgress
{
    public GameSettingsData gameData;

    public PlayerProgress(LevelSettings defaultLevelSettings) => 
        gameData = new GameSettingsData(defaultLevelSettings);
}
