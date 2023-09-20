using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    private Rigidbody2D _rigidbody;

    private bool _movementEnabled = false;

    private void OnEnable() => 
        Init();

    private void FixedUpdate() => 
        MovePlayer();

    public void EnabeMovement() => 
        _movementEnabled = true;

    public void SetSpeed(float newSpeedValue) => 
        _speed = newSpeedValue;

    private void MovePlayer()
    {
        if (!_movementEnabled) return;
       
        Vector2 direction = new (_speed * Time.fixedDeltaTime * 1f, _rigidbody.velocity.y);
        _rigidbody.velocity = direction;
    }

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _movementEnabled = false;
    }
}
