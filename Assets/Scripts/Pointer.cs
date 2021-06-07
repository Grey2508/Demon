using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Camera Camera;

    public GameObject CrossedBomb;
    public GameObject SimpleBomb;

    public int CountBombs = 3;
    public Explosion Explosion;

    public UIBomb UIBomb;

    private Vector3 _cursorWorldPosition;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        _cursorWorldPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        _cursorWorldPosition.z = 0;

        transform.position = _cursorWorldPosition;
    }

    void Update()
    {
        if (CountBombs <= 0)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            SimpleBomb.SetActive(false);
            Invoke(nameof(CursorOn), Explosion.CoolingPeriod);

            Explosion.SetPosition(_cursorWorldPosition);
            Explosion.Explode();

            UIBomb.ToggleToUsed(--CountBombs);
        }
    }

    private void CursorOn()
    {
        if (CountBombs <= 0)
            CrossedBomb.SetActive(true);
        else
            SimpleBomb.SetActive(true);
    }

    public void Reset()
    {
        CountBombs = 3;

        CrossedBomb.SetActive(false);
        SimpleBomb.SetActive(true);

        for (int i = 0; i < 3; i++)
            UIBomb.ToggleToReady(i);
    }
}
