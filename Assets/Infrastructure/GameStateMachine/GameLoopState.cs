using System;
using UnityEngine;

public class GameLoopState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;

    private string _currentLevelDifficulty;

    public GameLoopState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
    }

    public void Enter()
    {
        Debug.Log("GameLoopState");

        GameplayCanvas.OnMainMenuButton += LoadMainMenu;
        GameplayCanvas.OnRestartLevel += RestartLevel;
       
    }
    public void Exit()
    {
        GameplayCanvas.OnMainMenuButton -= LoadMainMenu;
        GameplayCanvas.OnRestartLevel -= RestartLevel;
    }

    private void LoadMainMenu() =>
        _gameStateMachine.Enter<LoadMainMenuState, string>(Constants.MAIN_MENU_SCENE_NAME);

    private void RestartLevel() =>
        _gameStateMachine.Enter<LoadLevelState, string>(_sceneLoader.GetCurrentLevelName());
}
