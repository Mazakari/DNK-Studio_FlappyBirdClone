using System;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] private int _playerLayer;

    public static event Action OnObstacleCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            // Send callback for GameplayState
            Debug.Log("Wall collision");
            OnObstacleCollision?.Invoke();
        }
    }
}
