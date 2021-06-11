using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public Body Body;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SwitchToDynamic()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    public void SwitchToKinematic()
    {
        _rigidbody2D.velocity = Vector2.zero;

        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.usedByEffector)
            Body.SwitchToDynamic();
    }
}
