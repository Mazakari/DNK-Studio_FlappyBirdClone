using System;
using UnityEngine;
using UnityEngine.UI;

public class GameplayCanvas : MonoBehaviour 
{
    [SerializeField] private GameObject _LevelLosePopup;

    [SerializeField] private Button _mainMenuButton;
    //[SerializeField] private CurrentLevelDisplay _levelDisplay;

    private ITimeService _timeService;

    public static Action OnRestartLevel;
    public static Action OnMainMenuButton;

    private void OnEnable()
    {
        _timeService = AllServices.Container.Single<ITimeService>();
        DeathTrigger.OnGameOver += ShowLevelLosePopup;

        InitPopups();
        UpdateLevelDifficulty();
    }

    private void OnDisable()
    {
        DeathTrigger.OnGameOver -= ShowLevelLosePopup;

        _mainMenuButton.onClick.RemoveAllListeners();
        _timeService.ResumeGame();
    }
    private void InitPopups() => 
        _LevelLosePopup.SetActive(false);

    private void ShowLevelLosePopup()
    {
        _timeService.PauseGame();
        _LevelLosePopup.SetActive(true);
    }

    // Send callback for GameLoopState
    public void LoadMainMenu() => 
        OnMainMenuButton?.Invoke();

    private void UpdateLevelDifficulty()
    {
        // TO DO 
    }
}
