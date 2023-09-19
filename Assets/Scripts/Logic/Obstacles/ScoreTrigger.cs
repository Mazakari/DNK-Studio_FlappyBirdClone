using System;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    [SerializeField] private int _playerLayer;
    [SerializeField] private ShowScore _scoreDisplay;
    [SerializeField] private int _scoreValue = 1;

    [Space(10)]
    [Header("Audio")]
    [SerializeField] private ItemSound _itemSound;

    public static event Action<int> OnScoreChange;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == _playerLayer)
        {
            PlayItemSound();
            ShowScore();
            SendOnScoreChangeCallback();
        }
    }

    private void PlayItemSound()
    {
        if (_itemSound)
        {
            _itemSound.Play();
        }
    }
    private void ShowScore() =>
       _scoreDisplay.ShowScoreText(_scoreValue);
    private void SendOnScoreChangeCallback() =>
      OnScoreChange?.Invoke(_scoreValue);
    }
