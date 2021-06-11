using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp : MonoBehaviour
{
    public Animator Animator;
    public float CoolingDuration = 1;
    public float Force;

    public PointEffector2D Magnet;

    private bool _cooling;
    private Rigidbody2D _collisionBody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_cooling)
            return;

        Magnet.enabled = true;

        Animator.SetTrigger("Hit");
        _cooling = true;

        _collisionBody = collision.attachedRigidbody;

        Invoke(nameof(StopCooling), CoolingDuration);
    }

    private void StopCooling()
    {
        _cooling = false;
    }

    private void AddForce()
    {
        Magnet.enabled = false;

        _collisionBody.AddForce(new Vector2(0, Force), ForceMode2D.Impulse);
    }

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
    }
}
