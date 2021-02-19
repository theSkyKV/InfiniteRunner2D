using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _stepSize = 3;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void TryToMoveUp()
    {
        if (_targetPosition.y < GameCamera.Border)
            SetNextPosition(_stepSize);
    }

    public void TryToMoveDown()
    {
        if (_targetPosition.y > - GameCamera.Border)
            SetNextPosition(-_stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + stepSize);
    }
}
