using TMPro;
using UnityEngine;

public class TotalScoreCount : MonoBehaviour
{
    [SerializeField] private TMP_Text _totalScoreText;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void UpdateScoreCounter()
    {
        //_totalScoreText.text = _levelProgressService.PlayerScores.ToString();
    }
}
