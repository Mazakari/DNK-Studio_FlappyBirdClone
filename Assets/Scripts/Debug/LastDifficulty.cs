using System;
using TMPro;
using UnityEngine;

public class LastDifficulty : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lastDifficultyText;

    private IGameSettingsService _gameSettingsService;

    private void OnEnable()
    {
        SetServiceReferrence();
        DisplayLastDeifficulty();
    }

    private void SetServiceReferrence() => 
        _gameSettingsService = AllServices.Container.Single<IGameSettingsService>();

    private void DisplayLastDeifficulty()
    {
        try
        {
            _lastDifficultyText.text = _gameSettingsService.CurrentLevelSettings.difficulty.ToString();
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
