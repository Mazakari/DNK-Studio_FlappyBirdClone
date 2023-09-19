using UnityEngine;

public class LoadProgressState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;


    public LoadProgressState(
        GameStateMachine gameStateMachine, 
        IPersistentProgressService progressService, 
        ISaveLoadService saveLoadService)
    {
        _gameStateMachine = gameStateMachine;
        _progressService = progressService;
        _saveLoadService = saveLoadService;
    }

    public void Enter()
    {
        Debug.Log("LoadProgressState");
        LoadProgressOrInitNew();
        _gameStateMachine.Enter<LoadMainMenuState, string>(Constants.MAIN_MENU_SCENE_NAME);
    }

    public void Exit()
    {
    }

    private void LoadProgressOrInitNew() =>
        _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

    private PlayerProgress NewProgress()
    {
        Debug.Log("Cloud Progress is null. Create new progress");
        return new();
    }
}
