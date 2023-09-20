using UnityEngine;

public class LevelBorders : MonoBehaviour
{
    [SerializeField] private Transform _topBorder;
    [SerializeField] private Transform _bottomBorder;

    private Camera _camera;
    private float _camHeight;

    private void OnEnable()
    {
        CacheCamera();
        SetBorders();
    }

    private void CacheCamera() => 
        _camera = Camera.main;
    private void SetBorders()
    {
        GetCameraHeight();
        CalculateAndSetBordersPositions();
    }

    private void GetCameraHeight() => 
        _camHeight = 2f * _camera.orthographicSize;

    private void CalculateAndSetBordersPositions()
    {
        SetTopBorder();
        SetBottomBorder();
    }
    private void SetTopBorder()
    {
        Vector2 borderPosition = Vector2.zero;

        borderPosition.y += _camHeight / 2f;
        _topBorder.position = borderPosition;
    }
    private void SetBottomBorder()
    {
        Vector2 borderPosition = Vector2.zero;

        borderPosition.y -= _camHeight / 2f;
        _bottomBorder.position = borderPosition;
    }
}
