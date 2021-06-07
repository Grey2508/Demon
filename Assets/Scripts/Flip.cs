using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public void FlipToLeft()
    {
        gameObject.transform.localScale = new Vector2(1,1);
    }

    public void FlipToRight()
    {
        gameObject.transform.localScale = new Vector2(-1, 1);
    }
}
