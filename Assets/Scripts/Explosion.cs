using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float CoolingPeriod = 0.5f;

    [SerializeField] private GameObject EffectObject;
    [SerializeField] private GameObject ForceObject;

    private bool _cooling;

    public void Explode()
    {
        if (_cooling)
            return;

        _cooling = true;

        EffectObject.SetActive(true);
        ForceObject.SetActive(true);

        Invoke("HideObjects", CoolingPeriod);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Trigger {collision.gameObject.name}");

        collision.gameObject.GetComponentInParent<Body>().SwitchToDynamic();
    }

    void HideObjects()
    {
        EffectObject.SetActive(false);
        ForceObject.SetActive(false);

        _cooling = false;
    }

    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
