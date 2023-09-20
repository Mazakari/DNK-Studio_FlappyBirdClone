using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMove))]
public class LaunchPlayer : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerMove _playerMove;
    [SerializeField] private  float _force = 10f;

    private bool _isActive = false;
    private Vector2 _direction = Vector2.up;

    private IInputService _inputService;

    private void OnEnable()
    {
        GetComponentsRefenences();

        _inputService = AllServices.Container.Single<IInputService>();

        _inputService.InputActions.Player.Launch.started += PushPlayerUp;

        InitRigidbody();
    }

    private void OnDisable() => 
        _inputService.InputActions.Player.Launch.started -= PushPlayerUp;

    private void GetComponentsRefenences()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerMove = GetComponent<PlayerMove>();
    }

    private void PushPlayerUp(InputAction.CallbackContext context)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        Launch();
    }
    private void Launch()
    {
        if (_isActive == false)
        {
            SetRigidbodyToDynamic();
            EnablePlayerMovement();
            _isActive = true;
        }

        AddPlayerLaunchForce(_direction);
    }

    private void SetRigidbodyToDynamic() =>
       _rigidbody.isKinematic = false;
    private void EnablePlayerMovement() =>
        _playerMove.EnabeMovement();

    private void InitRigidbody()
    {
        _isActive = false;
        _rigidbody.velocity = Vector2.zero;
        SetRigidbodyToKinematic();
    }

    private void SetRigidbodyToKinematic() => 
        _rigidbody.isKinematic = true;

    private void AddPlayerLaunchForce(Vector2 direction) =>
        _rigidbody.AddForce(direction * _force, ForceMode2D.Impulse);
}
