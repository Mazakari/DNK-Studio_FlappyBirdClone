using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettingsSO", menuName = "Levels/Level Settings", order = 1)]
public class LevelSettingSO : ScriptableObject
{
    //public Difficulty difficulty;

    public float playerSpeed;
    public GameObject wallPrefab;
}
