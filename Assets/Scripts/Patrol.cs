using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Rigth
}

public class Patrol : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;

    public float Speed = 1;

    public float StopTime = 0.5f;

    public Direction CurrentDirection;

    public Transform RayStart;

    private bool _isStopped;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    private void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }

    private void Update()
    {
        if (_isStopped)
            return;

        int sign = (CurrentDirection == Direction.Left ? -1 : 1);

        float newX = transform.position.x + sign * Speed * Time.deltaTime;
        float newY = transform.position.y;

        transform.position = new Vector3(newX, newY, 0);

        if (newX < LeftTarget.position.x)
        {
            CurrentDirection = Direction.Rigth;
            _isStopped = true;
            Invoke(nameof(ContinuePatrol), StopTime);

            EventOnLeftTarget.Invoke();
        }
        if (newX > RightTarget.position.x)
        {
            CurrentDirection = Direction.Left;
            _isStopped = true;
            Invoke(nameof(ContinuePatrol), StopTime);

            EventOnRightTarget.Invoke();
        }

        RaycastHit2D hit = Physics2D.Raycast(RayStart.position, Vector2.down);
        if (hit)
        {
            transform.position = hit.point;
        }
    }

    void ContinuePatrol()
    {
        _isStopped = false;
    }

    //”ничтожить точки
    private void OnDestroy()
    {
        if (LeftTarget != null)
            Destroy(LeftTarget.gameObject);
        if (RightTarget != null)
            Destroy(RightTarget.gameObject);
    }
}
