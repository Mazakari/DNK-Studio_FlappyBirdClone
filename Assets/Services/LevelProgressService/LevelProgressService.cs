using System;

public class LevelProgressService : ILevelProgressService
{
    private int _playerScores = 0;
    public int PlayerScores => _playerScores;

    public event Action OnTotalScoresChanged;

    public void AddScores(int value)
    {
        _playerScores += value;
        OnTotalScoresChanged?.Invoke();
    }

    public void ResetScores()
    {
        _playerScores = 0;
        OnTotalScoresChanged?.Invoke();
    }
}
