using UnityEngine;

public class PlayerControlsHandler : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private Rigidbody2D _rb;

    private void OnEnable()
    {
        //LevelState.OnLevelLoaded += DisableControls;
        //LevelState.OnLevelStart += EnableControls;
    }

    private void OnDisable()
    {
        //LevelState.OnLevelLoaded -= DisableControls;
        //LevelState.OnLevelStart -= EnableControls;
    }

    private void EnableControls()
    {
        _playerMove.enabled = true;
        _rb.isKinematic = false;
    }

    private void DisableControls()
    {
        if (_playerMove && _rb)
        {
            _playerMove.enabled = false;
            _rb.isKinematic = true;

            _rb.velocity = Vector3.zero;
        }
    }
}
