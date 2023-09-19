using UnityEngine;

public class LoadProgressState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly IGameSettingsService _gameSettingsService;


    public LoadProgressState(
        GameStateMachine gameStateMachine, 
        IPersistentProgressService progressService, 
        ISaveLoadService saveLoadService,
        IGameSettingsService gameSettingsService)
    {
        _gameStateMachine = gameStateMachine;
        _progressService = progressService;
        _saveLoadService = saveLoadService;
        _gameSettingsService = gameSettingsService;
    }

    public void Enter()
    {
        Debug.Log("LoadProgressState");

        LoadProgressOrInitNew();
        SetCurrentLevelSettings();

        LoadMainMenuGameState();
    }

    public void Exit() { }

    private void LoadProgressOrInitNew() =>
        _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
    private void SetCurrentLevelSettings() =>
       _gameSettingsService.SetCurrentLevelSettings(_progressService.Progress.gameData.levelSettings);
    private void LoadMainMenuGameState() =>
       _gameStateMachine.Enter<LoadMainMenuState, string>(Constants.MAIN_MENU_SCENE_NAME);

    private PlayerProgress NewProgress()
    {
        Debug.Log("Cloud Progress is null. Create new progress");

        LevelSettings defaultLevelSettings = LoadDefaultLevelSettings();

        return new(defaultLevelSettings);
    }

    private LevelSettings LoadDefaultLevelSettings()
    {
        LevelSettings settings = new();
        LevelSettingSO defaultSettings = LoadDeafultSO();

        settings = ValidateLoadedDefaultSettingsSO(settings, defaultSettings);

        return settings;
    }
    private LevelSettingSO LoadDeafultSO() =>
       Resources.Load<LevelSettingSO>(AssetPath.LEVEL_SETTINGS_SO_DEFAULT);

    private LevelSettings ValidateLoadedDefaultSettingsSO(LevelSettings settings, LevelSettingSO defaultSettings)
    {
        if (defaultSettings != null)
        {
            settings = defaultSettings.settings;
        }
        else
        {
            Debug.LogError("Default settings SO is null. Load placeholder level settings");
        }

        return settings;
    }
}
