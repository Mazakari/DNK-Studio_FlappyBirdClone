using System;

[Serializable]
public class PlayerProgress
{
    public GameSettingsData gameData;

    public PlayerProgress() => 
        gameData = new GameSettingsData();
}
