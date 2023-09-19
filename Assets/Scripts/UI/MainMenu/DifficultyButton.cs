using System;
using UnityEngine;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private LevelDifficulty _difficulty;
    private IGameSettingsService _gameSettingsService;

    public static event Action OnDifficultySelected;

    private void OnEnable() => 
        GetServiceReference();

    private void GetServiceReference() => 
        _gameSettingsService = AllServices.Container.Single<IGameSettingsService>();

    public void SelecDifficulty()
    {
        _gameSettingsService.SetCurrentLevelSettings(_difficulty);

        SendOnDifficultySelectedCallback();
    }

    private static void SendOnDifficultySelectedCallback() => 
        OnDifficultySelected?.Invoke();
}
