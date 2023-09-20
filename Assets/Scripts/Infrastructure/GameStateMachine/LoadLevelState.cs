using UnityEngine;

public class LoadLevelState : IPayloadedState<string>
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    private readonly IPersistentProgressService _progressService;
    private readonly ILevelProgressService _levelProgressService;
    private readonly IGameSettingsService _gameSettingsService;

    public LoadLevelState(
        GameStateMachine gameStateMachine, 
        SceneLoader sceneLoader, 
        LoadingCurtain curtain, 
        IGameFactory gameFactory, 
        IPersistentProgressService progressService, 
        ILevelProgressService levelProgressService,
        IGameSettingsService gameSettingsService)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
        _gameFactory = gameFactory;
        _progressService = progressService;
        _levelProgressService = levelProgressService;
        _gameSettingsService = gameSettingsService;
    }

    public void Enter(string sceneName)
    {
        Debug.Log("LoadLevelState");
        _curtain.Show();
        _gameFactory.Cleanup();
        _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit() => 
        _curtain.Hide();

    private void OnLoaded()
    {
        InitGameWorld();
        ResetTotalLevelScores();
        InformProgressReaders();

        _gameStateMachine.Enter<GameLoopState>();
    }

    private void InitGameWorld()
    {
        GameObject spawnPos = GameObject.FindGameObjectWithTag(Constants.PLAYER_SPAWN_POINT_TAG);
        GameObject player = SpawnPlayer(spawnPos);

        SetPlayerDifficultySpeed(player);
        SetPlayerFollowers(player);

        _gameFactory.CreateLevelHud();
    }

   

    private GameObject SpawnPlayer(GameObject spawnPos) =>
       _gameFactory.CreatePlayer(spawnPos);

    private void SetPlayerDifficultySpeed(GameObject player)
    {
        if (player.TryGetComponent(out PlayerMove move))
        {
            float difficultySpeed = _gameSettingsService.CurrentLevelSettings.playerSpeed;
            move.SetSpeed(difficultySpeed);
            Debug.Log($"{_gameSettingsService.CurrentLevelSettings.difficulty} difficulty player speed is {difficultySpeed}");
        }
    }

    private void SetPlayerFollowers(GameObject player)
    {
        FollowTarget[] followers = Object.FindObjectsOfType<FollowTarget>();
        if (followers != null || followers.Length > 0)
        {
            foreach (var follower in followers)
            {
                follower.SetTarget(player.transform);
            }

        }
    }

    private void ResetTotalLevelScores() =>
       _levelProgressService.ResetScores();
   
    private void InformProgressReaders()
    {
        foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
        {
            progressReader.LoadProgress(_progressService.Progress);
        }
    }
}