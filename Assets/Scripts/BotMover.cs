using UnityEngine;

public class BotMover : MonoBehaviour
{
    private Vector3 _targetPoint;
    private bool _isWalking;
    private float _moveSpeed = 5;
    private float _distanceToTarget = 0.1f;

    private void Update()
    {
        if (_isWalking)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            _targetPoint,
            _moveSpeed * Time.deltaTime
        );

        if (transform.position.IsEnoughClose(_targetPoint, _distanceToTarget))
        {
            Stop();
        }
    }

    public void MoveToPoint(Vector3 newPosition)
    {
        _isWalking = true;
        _targetPoint = newPosition;
    }

    public void Stop()
    {
        _isWalking = false;
    }
}
