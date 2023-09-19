using System.Collections.Generic;
using UnityEngine;

public class GameSettingsService : IGameSettingsService
{
    public LevelSettings CurrentLevelSettings { get; private set; }

    private readonly Dictionary<LevelDifficulty, LevelSettings> _settings = new();

    public GameSettingsService() => 
        InitLevelSettingsDictionary();

    public void SetCurrentLevelSettings(LevelSettings newSettings)
    {
        CurrentLevelSettings = newSettings;
        Debug.Log($"Current levelSettings = {CurrentLevelSettings.difficulty}");
    }

    public void SetCurrentLevelSettings(LevelDifficulty difficulty)
    {
        LevelSettings newSettings = GetSettingsForDifficulty(difficulty);
        CurrentLevelSettings = newSettings;

        Debug.Log($"Current levelSettings = {CurrentLevelSettings.difficulty}");
    }


    private void InitLevelSettingsDictionary()
    {
        LevelSettingSO[] settingsTemplates = Resources.LoadAll<LevelSettingSO>(AssetPath.LEVEL_SETTINGS_SO);

        for (int i = 0; i < settingsTemplates.Length; i++)
        {
            if (!_settings.TryAdd(settingsTemplates[i].settings.difficulty, settingsTemplates[i].settings))
            {
                Debug.Log("Level difficulty setting already exist");
            }
        }
    }
    private LevelSettings GetSettingsForDifficulty(LevelDifficulty difficulty)
    {
        LevelSettings newSettings = new();

        if (_settings.TryGetValue(difficulty, out LevelSettings settings))
        {
            newSettings = settings;
        }
        else
        {
            Debug.LogError("Level difficulty not exist. Load placeholder settings");
        }

        return newSettings;
    }
}
