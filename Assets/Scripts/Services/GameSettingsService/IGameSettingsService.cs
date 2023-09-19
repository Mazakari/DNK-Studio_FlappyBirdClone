public interface IGameSettingsService : IService
{
    LevelSettings CurrentLevelSettings { get; }

    void SetCurrentLevelSettings(LevelSettings newSettings);
    void SetCurrentLevelSettings(LevelDifficulty difficulty);
}