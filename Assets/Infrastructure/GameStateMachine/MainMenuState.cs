using UnityEngine;

public class MainMenuState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    public MainMenuState(GameStateMachine gameStateMachine) => 
        _gameStateMachine = gameStateMachine;

    public void Enter()
    {
        Debug.Log("MainMenuState");
        MainMenuCanvas.OnStartGameButtonPress += StartGame;
    }

    public void Exit() =>
        MainMenuCanvas.OnStartGameButtonPress -= StartGame;

    private void StartGame(string levelName) =>
      _gameStateMachine.Enter<LoadLevelState, string>(levelName);
}
