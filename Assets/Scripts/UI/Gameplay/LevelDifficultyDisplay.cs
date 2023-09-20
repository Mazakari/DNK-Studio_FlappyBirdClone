using TMPro;
using UnityEngine;

public class LevelDifficultyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _displayText;

    private IGameSettingsService _gameSettingsService;

    private void OnEnable()
    {
        _gameSettingsService = AllServices.Container.Single<IGameSettingsService>();
        UpdateDifficultyText();
    }

    private void UpdateDifficultyText()
    {
        _displayText.text = _gameSettingsService.CurrentLevelSettings.difficulty.ToString();
    }

}
