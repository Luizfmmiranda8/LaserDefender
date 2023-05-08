using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    #endregion

    #region EVENTS
    void Update()
    {
        MovePlayer();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    #endregion

    #region METHODS
    void MovePlayer()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }
    #endregion
}
