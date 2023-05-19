using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region VARIABLES
    [Header("Time")]
    [SerializeField] float shakeDuration = 1f;

    [Header("Potency")]
    [SerializeField] float shakeMagnitude = 0.5f;

    [Header("Position")]
    Vector3 initialPosition;
    #endregion

    #region EVENTS
    void Start()
    {
        initialPosition = transform.position;
    }
    #endregion

    #region METHODS
    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;

        while(elapsedTime < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        transform.position = initialPosition;
    }
    #endregion
}
