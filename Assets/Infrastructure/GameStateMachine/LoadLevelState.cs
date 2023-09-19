using UnityEngine;

public class LoadLevelState : IPayloadedState<string>
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    private readonly IPersistentProgressService _progressService;
    private readonly ILevelProgressService _levelProgressService;

    public LoadLevelState(
        GameStateMachine gameStateMachine, 
        SceneLoader sceneLoader, 
        LoadingCurtain curtain, 
        IGameFactory gameFactory, 
        IPersistentProgressService progressService, 
        ILevelProgressService levelProgressService)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
        _curtain = curtain;
        _gameFactory = gameFactory;
        _progressService = progressService;
        _levelProgressService = levelProgressService;
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

        _gameFactory.CreateLevelHud();
    }

    private GameObject SpawnPlayer(GameObject spawnPos) =>
       _gameFactory.CreatePlayer(spawnPos);
   

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