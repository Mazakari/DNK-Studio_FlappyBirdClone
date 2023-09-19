using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private float _speed = 10;

    private void Update() => 
        MovePlayer();

    public void MovePlayer() =>
       transform.Translate(_speed * Time.deltaTime * new Vector2(_input.MoveInputX, 0));
}
