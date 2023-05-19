using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    #region VARIABLES
    [Header("Speed")]
    [SerializeField] Vector2 moveSpeed;

    [Header("Distance")]
    Vector2 offset;

    [Header("Material")]
    Material material;
    #endregion

    #region EVENTS
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        MoveBackground();
    }
    #endregion

    #region METHODS
    void MoveBackground()
    {
        offset = moveSpeed * Time.deltaTime;

        material.mainTextureOffset += offset;
    }
    #endregion
}
