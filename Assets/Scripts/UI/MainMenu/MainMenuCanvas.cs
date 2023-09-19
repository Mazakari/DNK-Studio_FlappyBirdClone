using System;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour, ISavedProgress
{
    [Header("Popups")]
    [SerializeField] private GameObject _settingsPopup;
    [SerializeField] private GameObject _selectDifficultyPopup;

    public static Action<string> OnStartGameButtonPress;

    private IGameSettingsService _settingsService;

    private void OnEnable()
    {
        _settingsService = AllServices.Container.Single<IGameSettingsService>();

        SettingsPopup.OnSettingsSaved += HideSettingsPopup;
        DifficultyButton.OnDifficultySelected += StartGame;

        InitPopups();
    }
  
    private void OnDisable() => 
        SettingsPopup.OnSettingsSaved -= HideSettingsPopup;

    

    public void ShowSettingsPopup() =>
        _settingsPopup.SetActive(true);

    public void QuitGame() => 
        Application.Quit();
    private void StartGame() =>
       OnStartGameButtonPress?.Invoke(Constants.FIRST_LEVEL_NAME);

    private void HideSettingsPopup() =>
        _settingsPopup.SetActive(false);

    private void InitPopups()
    {
        _settingsPopup.SetActive(false);
        _selectDifficultyPopup.SetActive(false);
    }

    public void UpdateProgress(PlayerProgress progress) 
    {
        // TO DO Save selected difficulty
        Debug.Log("Save Progress Main Menu Canvas");
        progress.gameData.levelSettings = _settingsService.CurrentLevelSettings;

    }
    public void LoadProgress(PlayerProgress progress)
    {
        
    }
}
