using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private bool _ignoreX;
    [SerializeField] private bool _ignoreY;

    private Transform _target;
    private Vector3 _offset;

    private void LateUpdate() => 
        FollowTargetPosition();

    public void SetTarget(Transform target)
    {
        _target = target;
        SetOffset();
    }
    private void SetOffset() =>
       _offset = transform.position - _target.position;

    private void FollowTargetPosition()
    {
        if (_target == null) return;

        Vector3 targetPosition = CalculateTargetPosition();
        targetPosition = IgnoreSelectedAxis(targetPosition);
        transform.position = targetPosition;
    }
    private Vector3 CalculateTargetPosition()
    {
        Vector3 targetPosition = _target.position + _offset;
        targetPosition.z = transform.position.z;

        return targetPosition;
    }
    private Vector3 IgnoreSelectedAxis(Vector3 targetPosition)
    {
        if (_ignoreX == true)
        {
            targetPosition.x = transform.position.x;
        }
        if (_ignoreY == true)
        {
            targetPosition.y = transform.position.y;
        }

        return targetPosition;
    }
}
