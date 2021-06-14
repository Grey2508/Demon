using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScore : MonoBehaviour
{
    public int MaxHeight
    {
        get;
        private set;
    }

    public Transform Target;
    public OutputStatistic OutputStatistic;
    public GameObject Frame;

    public float TimeShowNewMaxHeight = 0.5f;

    private float _oldTimeScale;

    public void ChangeMaxHeight(int height)
    {
        transform.position = Target.position;

        MaxHeight = height;
        OutputStatistic.WriteMaxHeight(MaxHeight);

        float frameRotationZ = Random.Range(-15, 15);

        Frame.transform.rotation = Quaternion.Euler(0, 0, frameRotationZ);
        Frame.SetActive(true);

        _oldTimeScale = Time.timeScale;
        Time.timeScale = 0;

        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        for (float t = 0; t < TimeShowNewMaxHeight; t += Time.unscaledDeltaTime)
        {
            yield return null;
        }

        Frame.SetActive(false);
        Time.timeScale = _oldTimeScale;
    }
}
