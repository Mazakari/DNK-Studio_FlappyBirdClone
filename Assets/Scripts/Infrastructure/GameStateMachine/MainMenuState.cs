using UnityEngine;

public class MainMenuState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly ISaveLoadService _saveLoadService;

    public MainMenuState(GameStateMachine gameStateMachine, ISaveLoadService saveLoadService)
    {
        _gameStateMachine = gameStateMachine;
        _saveLoadService = saveLoadService;
    }

    public void Enter()
    {
        Debug.Log("MainMenuState");
        MainMenuCanvas.OnStartGameButtonPress += LoadLevelScene;
    }

    public void Exit()
    {
        _saveLoadService.SaveProgress();
        MainMenuCanvas.OnStartGameButtonPress -= LoadLevelScene;
    }

    private void LoadLevelScene(string levelName) =>
      _gameStateMachine.Enter<LoadLevelState, string>(levelName);
}
