using TMPro;
using UnityEngine;

public class LevelLosePopup : MonoBehaviour
{
    [SerializeField] private TMP_Text _maxScoresCounterText;
    [SerializeField] private TMP_Text _currentDifficultyText;

    private IGameSettingsService _gameSettingsService;

    private void OnEnable()
    {
        _gameSettingsService = AllServices.Container.Single<IGameSettingsService>();
        ShowLevelResults();
    }

    public void RestartLevel() =>
      GameplayCanvas.OnRestartLevel?.Invoke();

    private void ShowLevelResults()
    {
        int maxScores = -1;
       TotalScoreCount scoresCounter = FindObjectOfType<TotalScoreCount>();
        if (scoresCounter != null)
        {
            maxScores = scoresCounter.TotalScores;
        }
        _maxScoresCounterText.text = maxScores.ToString();
        _currentDifficultyText.text = _gameSettingsService.CurrentLevelSettings.difficulty.ToString();
    }
}
