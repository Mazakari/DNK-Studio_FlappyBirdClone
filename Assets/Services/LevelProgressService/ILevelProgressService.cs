using System;

public interface ILevelProgressService : IService
{
    int PlayerScores { get; }

    event Action OnTotalScoresChanged;

    void AddScores(int value);
    void ResetScores();
}