using System;
using UnityEngine;

[Serializable]
public class GameSettingsData
{
    public GameObject _currentDifficulty;

    public float musicVolume;
    public bool musicToggle;

    public float soundVolume;
    public bool soundToggle;

    // TO DO pass default dificulty
    public GameSettingsData()
	{
        //_currentDifficulty = GameDifficulty.Normal;

        musicVolume = 0.5f;
        musicToggle = true;

        soundVolume = 0.5f;
        soundToggle = true;
    }
}
