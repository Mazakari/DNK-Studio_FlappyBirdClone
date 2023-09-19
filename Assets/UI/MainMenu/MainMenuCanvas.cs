using System;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour, ISavedProgress
{
    [Header("Settings Popup")]
    [SerializeField] private GameObject _settingsPopup;

    public static Action<string> OnStartGameButtonPress;

    private void OnEnable()
    {
        SettingsPopup.OnSettingsSaved += HideSettingsPopup;

        InitPopups();
    }
  
    private void OnDisable() => 
        SettingsPopup.OnSettingsSaved -= HideSettingsPopup;

    public void StartGame() =>
       OnStartGameButtonPress?.Invoke(Constants.FIRST_LEVEL_NAME);

    public void ShowSettingsPopup() =>
        _settingsPopup.SetActive(true);

    public void QuitGame() => 
        Application.Quit();

    private void HideSettingsPopup() =>
        _settingsPopup.SetActive(false);

    private void InitPopups() => 
        _settingsPopup.SetActive(false);

    public void UpdateProgress(PlayerProgress progress) 
    {
        // TO DO Save selected difficulty
    }
    public void LoadProgress(PlayerProgress progress)
    {
        // TO DO Load current difficulty
    }
}
