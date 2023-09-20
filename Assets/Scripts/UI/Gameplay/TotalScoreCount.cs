using TMPro;
using UnityEngine;

public class TotalScoreCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _totalScoreText;
    public int TotalScores => _totalScores;
    private int _totalScores = 0;

    private void OnEnable()
    {
        ScoreTrigger.OnScoreChange += UpdateScoreCounter;

        InitCounter();
    }

    private void OnDisable() => 
        ScoreTrigger.OnScoreChange -= UpdateScoreCounter;

    private void InitCounter()
    {
        _totalScores = 0;
        UpdateScoreCounter(_totalScores);
    }

    private void UpdateScoreCounter(int scoreToAdd)
    {
        _totalScores += scoreToAdd;
        _totalScoreText.text = _totalScores.ToString();
    }
}
