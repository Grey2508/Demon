using System;
using System.Collections;
using UnityEngine;

public enum FlyDirection
{
    Up,
    Down,
    None
}
public class FlyManager : MonoBehaviour
{
    public static bool Fly;

    public Transform MarkerHeight;

    public Body DemonBody;
    public Pointer Pointer;

    public Wall[] Walls;

    public OutputStatistic OutputStatistic;

    public TopScore TopScore;

    private int _lastHeight = 0;
    private int _totalMovement = 0;

    private int _index;
    private int _prevIndex;
    private int _nextIndex;

    private FlyDirection _currentDirection;

    void Update()
    {
        if (!Fly)
            return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Reset();

            return;
        }

        int height = (int)MarkerHeight.position.y;
        OutputStatistic.WriteHeight(height);

        if (height == 0)
            MoveWallsToZero();

        int deltaHeight = height - _lastHeight;

        ChangeTotalMovement(deltaHeight);

        if (deltaHeight != 0)
        {
            ShiftWalls(height, deltaHeight);

            _lastHeight = height;
        }
    }

    private void ShiftWalls(int height, int deltaHeight)
    {
        if (deltaHeight > 0)
        {
            if (_currentDirection != FlyDirection.Up)
            {
                ShiftIndexes();

                _currentDirection = FlyDirection.Up;
            }

            if (height > Walls[_nextIndex].GetY)
            {
                Walls[_prevIndex].Move(Walls[_nextIndex].GetPosition, 1);

                _prevIndex = _index;
                _index = _nextIndex;
                _nextIndex = (_index == Walls.Length - 1 ? 0 : _index + 1);
            }
        }

        if (deltaHeight < 0)
        {
            if (_currentDirection != FlyDirection.Down)
            {
                ShiftIndexes();

                if (TopScore.MaxHeight < height)
                    TopScore.ChangeMaxHeight(height);

                _currentDirection = FlyDirection.Down;
            }

            if (height < Walls[_index].GetY)
            {
                Walls[_prevIndex].Move(Walls[_nextIndex].GetPosition, -1);;

                _prevIndex = _index;
                _index = _nextIndex;
                _nextIndex = (_index == 0 ? Walls.Length - 1 : _index - 1);
            }
        }
    }

    private void ShiftIndexes()
    {
        int buf = _prevIndex;
        _prevIndex = _nextIndex;
        _nextIndex = buf;
    }

    private void ChangeTotalMovement(int deltaHeight)
    {
        SetTotalMovement(_totalMovement + Mathf.Abs(deltaHeight));
    }

    private void SetTotalMovement(int value)
    {
        _totalMovement = value;
        OutputStatistic.WriteTotalMovement(_totalMovement);
    }

    private void Reset()
    {
        Fly = false;

        MoveWallsToZero();

        DemonBody.SwitchToKinematic();
        Pointer.Reset();

        _lastHeight = 0;
        OutputStatistic.WriteHeight(0);
        SetTotalMovement(0);
    }

    private void MoveWallsToZero()
    {
        for (int i = 0; i < Walls.Length; i++)
            Walls[i].Move(Vector2.zero, i);

        _index = 0;
        _prevIndex = Walls.Length - 1;
        _nextIndex = _index + 1;
    }
}
