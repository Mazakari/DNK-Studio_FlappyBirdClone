using System;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    [SerializeField] private int _playerLayer;

    [Space(10)]
    [Header("Audio")]
    [SerializeField] private ItemSound _itemSound;

    public static event Action OnGameOver;

    private void OnTriggerEnter2D(Collider2D collider) => 
        CollideWithPlayer(collider);

    private void CollideWithPlayer(Collider2D collider)
    {
        if (collider.gameObject.layer == _playerLayer)
        {
            PlayItemSound();
            SendGameOverCallback();
        }
    }

    private void PlayItemSound()
    {
        if (_itemSound)
        {
            _itemSound.Play();
        }
    }

    private void SendGameOverCallback() => 
        OnGameOver?.Invoke();
}
