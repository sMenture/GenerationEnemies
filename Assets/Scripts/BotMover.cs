using UnityEngine;

public class BotMover : MonoBehaviour
{
    private Vector3 _targetPoint;
    private bool _isWalking;
    private float _moveSpeed = 5;

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

        if (Vector3.Distance(transform.position, _targetPoint) < 0.1f)
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
