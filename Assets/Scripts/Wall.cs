using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int WallHeight = 10;

    [SerializeField] private Imp[] Imps;

    public void Move(Vector2 position, int multiplier)
    {
        transform.position = position + Vector2.up * WallHeight * multiplier;

        int maxRandom = ((int)position.y) / 150;

        foreach (Imp imp in Imps)
        {
            if (Random.Range(0, maxRandom) == 0)
                imp.SetActive(true);
            else
                imp.SetActive(false);
        }
    }

    public Vector3 GetPosition
        => transform.position;

    public int GetY
        => (int)transform.position.y;
}
